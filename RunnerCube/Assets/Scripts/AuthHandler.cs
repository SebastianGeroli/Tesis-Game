// Copyright 2016 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif

namespace Firebase.Sample.Auth {
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using UnityEngine.UI;
	using ToastPlugin;
	using System.Collections;

	// Handler for UI buttons on the scene.  Also performs some
	// necessary setup (initializing the firebase app, etc) on
	// startup.
	public class AuthHandler:MonoBehaviour {
		bool userCreated;
		public InputField emailText;
		public InputField passwordText;
		public InputField displayNameText;
		protected Firebase.Auth.FirebaseAuth auth;
		protected Dictionary<string , Firebase.Auth.FirebaseUser> userByAuth =
		  new Dictionary<string , Firebase.Auth.FirebaseUser>();
		private string logText = "";
		protected string email = "";
		protected string password = "";
		protected string displayName = "";
		protected string phoneNumber = "";
		protected string receivedCode = "";
		// Whether to sign in / link or reauthentication *and* fetch user profile data.
		protected bool signInAndFetchProfile = true;
		// Flag set when a token is being fetched.  This is used to avoid printing the token
		// in IdTokenChanged() when the user presses the get token button.
		private bool fetchingToken = false;
		// Enable / disable password input box.
		// NOTE: In some versions of Unity the password input box does not work in
		// iOS simulators.
		bool UIEnabled = true;

		const int kMaxLogSize = 16382;
		Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;

		// When the app starts, check to make sure that we have
		// the required dependencies to use Firebase, and if not,
		// add them if possible.
		//Awake
		private void Awake() {
			userCreated = false;
			DontDestroyOnLoad( this.gameObject );
		}
		//Virtual Start
		public virtual void Start() {
			Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( task => {
				dependencyStatus = task.Result;
				if( dependencyStatus == Firebase.DependencyStatus.Available ) {
					InitializeFirebase();
				} else {
					Debug.LogError(
					  "Could not resolve all Firebase dependencies: " + dependencyStatus );
				}
			} );
		}

		// Handle initialization of the necessary firebase modules:
		protected void InitializeFirebase() {
			DebugLog( "Setting up Firebase Auth" );
			auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
			auth.StateChanged += AuthStateChanged;
			auth.IdTokenChanged += IdTokenChanged;
			AuthStateChanged( this , null );
		}

		// Exit if escape (or back, on mobile) is pressed.
		protected virtual void Update() {
			if( Input.GetKeyDown( KeyCode.Escape ) ) {
				Application.Quit();
			}
		}

		void OnDestroy() {
			auth.StateChanged -= AuthStateChanged;
			auth.IdTokenChanged -= IdTokenChanged;
			auth = null;
		}

		void DisableUI() {
			UIEnabled = false;
		}

		void EnableUI() {
			UIEnabled = true;
		}
		//FixedUpdate
		private void FixedUpdate() {
			if( userCreated ) {
				SceneManager.LoadScene("Menu");
				userCreated = false;
			}
		}
		// Output text to the debug log text field, as well as the console.
		public void DebugLog( string s ) {
			Debug.Log( s );
			logText += s + "\n";

			while( logText.Length > kMaxLogSize ) {
				int index = logText.IndexOf( "\n" );
				logText = logText.Substring( index + 1 );
			}

		}

		// Display additional user profile information.
		protected void DisplayProfile<T>( IDictionary<T , object> profile , int indentLevel ) {
			string indent = new String( ' ' , indentLevel * 2 );
			foreach( var kv in profile ) {
				var valueDictionary = kv.Value as IDictionary<object , object>;
				if( valueDictionary != null ) {
					DebugLog( String.Format( "{0}{1}:" , indent , kv.Key ) );
					DisplayProfile<object>( valueDictionary , indentLevel + 1 );
				} else {
					DebugLog( String.Format( "{0}{1}: {2}" , indent , kv.Key , kv.Value ) );
				}
			}
		}

		// Display user information reported
		protected void DisplaySignInResult( Firebase.Auth.SignInResult result , int indentLevel ) {
			string indent = new String( ' ' , indentLevel * 2 );
			DisplayDetailedUserInfo( result.User , indentLevel );
			var metadata = result.Meta;
			if( metadata != null ) {
				DebugLog( String.Format( "{0}Created: {1}" , indent , metadata.CreationTimestamp ) );
				DebugLog( String.Format( "{0}Last Sign-in: {1}" , indent , metadata.LastSignInTimestamp ) );
			}
			var info = result.Info;
			if( info != null ) {
				DebugLog( String.Format( "{0}Additional User Info:" , indent ) );
				DebugLog( String.Format( "{0}  User Name: {1}" , indent , info.UserName ) );
				DebugLog( String.Format( "{0}  Provider ID: {1}" , indent , info.ProviderId ) );
				DisplayProfile<string>( info.Profile , indentLevel + 1 );
			}
		}

		// Display user information
		protected void DisplayUserInfo( Firebase.Auth.IUserInfo userInfo , int indentLevel ) {
			string indent = new String( ' ' , indentLevel * 2 );
			var userProperties = new Dictionary<string , string> {
		{"Display Name", userInfo.DisplayName},
		{"Email", userInfo.Email},
		{"Photo URL", userInfo.PhotoUrl != null ? userInfo.PhotoUrl.ToString() : null},
		{"Provider ID", userInfo.ProviderId},
		{"User ID", userInfo.UserId}
	  };
			foreach( var property in userProperties ) {
				if( !String.IsNullOrEmpty( property.Value ) ) {
					DebugLog( String.Format( "{0}{1}: {2}" , indent , property.Key , property.Value ) );
				}
			}
		}

		// Display a more detailed view of a FirebaseUser.
		protected void DisplayDetailedUserInfo( Firebase.Auth.FirebaseUser user , int indentLevel ) {
			string indent = new String( ' ' , indentLevel * 2 );
			DisplayUserInfo( user , indentLevel );
			DataController.control.displayName = user.DisplayName;
			DataController.control.email = user.Email;
			DebugLog( String.Format( "{0}Anonymous: {1}" , indent , user.IsAnonymous ) );
			DebugLog( String.Format( "{0}Email Verified: {1}" , indent , user.IsEmailVerified ) );
			DebugLog( String.Format( "{0}Phone Number: {1}" , indent , user.PhoneNumber ) );
			var providerDataList = new List<Firebase.Auth.IUserInfo>( user.ProviderData );
			var numberOfProviders = providerDataList.Count;
			if( numberOfProviders > 0 ) {
				for( int i = 0; i < numberOfProviders; ++i ) {
					DebugLog( String.Format( "{0}Provider Data: {1}" , indent , i ) );
					DisplayUserInfo( providerDataList[i] , indentLevel + 2 );
				}
			}
		}

		// Track state changes of the auth object.
		void AuthStateChanged( object sender , System.EventArgs eventArgs ) {
			Firebase.Auth.FirebaseAuth senderAuth = sender as Firebase.Auth.FirebaseAuth;
			Firebase.Auth.FirebaseUser user = null;
			if( senderAuth != null )
				userByAuth.TryGetValue( senderAuth.App.Name , out user );
			if( senderAuth == auth && senderAuth.CurrentUser != user ) {
				bool signedIn = user != senderAuth.CurrentUser && senderAuth.CurrentUser != null;
				if( !signedIn && user != null ) {
					DebugLog( "Signed out " + user.UserId );
				}
				user = senderAuth.CurrentUser;
				userByAuth[senderAuth.App.Name] = user;
				if( signedIn ) {
					DebugLog( "Signed in " + user.UserId );
					displayName = user.DisplayName ?? "";
					DisplayDetailedUserInfo( user , 1 );
				}
			}
		}

		// Track ID token changes.
		void IdTokenChanged( object sender , System.EventArgs eventArgs ) {
			Firebase.Auth.FirebaseAuth senderAuth = sender as Firebase.Auth.FirebaseAuth;
			if( senderAuth == auth && senderAuth.CurrentUser != null && !fetchingToken ) {
				senderAuth.CurrentUser.TokenAsync( false ).ContinueWith(
				  task => DebugLog( String.Format( "Token[0:8] = {0}" , task.Result.Substring( 0 , 8 ) ) ) );
			}
		}

		// Log the result of the specified task, returning true if the task
		// completed successfully, false otherwise.
		protected bool LogTaskCompletion( Task task , string operation ) {
			bool complete = false;
			if( task.IsCanceled ) {
				DebugLog( operation + " canceled." );
			} else if( task.IsFaulted ) {
				DebugLog( operation + " encounted an error." );
				foreach( Exception exception in task.Exception.Flatten().InnerExceptions ) {
					string authErrorCode = "";
					Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
					if( firebaseEx != null ) {
						authErrorCode = String.Format( "AuthError.{0}: " ,
						  ( (Firebase.Auth.AuthError)firebaseEx.ErrorCode ).ToString() );
					}
					DebugLog( authErrorCode + exception.ToString() );
				}
			} else if( task.IsCompleted ) {
				DebugLog( operation + " completed" );
				complete = true;
			}
			return complete;
		}
		//Create User
		public void CreateUser() {
			CreateUserWithEmailAsync().ContinueWith( ( task ) => {
				if( LogTaskCompletion( task , "User Created" ) ) {
					userCreated = true;
				}


			});
		}
		// Create a user with the email and password.
		public Task CreateUserWithEmailAsync() {
			email = emailText.text;
			password = passwordText.text;
			displayName = displayNameText.text;
			DebugLog( String.Format( "Attempting to create user {0}..." , email ) );
			DisableUI();

			// This passes the current displayName through to HandleCreateUserAsync
			// so that it can be passed to UpdateUserProfile().  displayName will be
			// reset by AuthStateChanged() when the new user is created and signed in.
			string newDisplayName = displayNameText.text;
			return auth.CreateUserWithEmailAndPasswordAsync( email , password )
			.ContinueWith( ( task ) => {
				EnableUI();
				if( LogTaskCompletion( task , "User Creation" ) ) {
					var user = task.Result;
					DataController.control.email = email;
					DataController.control.password = password;
					//user.SendEmailVerificationAsync();
					DisplayDetailedUserInfo( user , 1 );
					return UpdateUserProfileAsync( newDisplayName: newDisplayName );
				}
				return task;
			} ).Unwrap();
			/*Cargar escena luego de que termine la seccion de arriba */
			/*Arreglo con corrutina de espera larga pero no es lo ideal*/
		}

		// Update the user's display name with the currently selected display name.
		public Task UpdateUserProfileAsync( string newDisplayName = null ) {
			if( auth.CurrentUser == null ) {
				DebugLog( "Not signed in, unable to update user profile" );
				return Task.FromResult( 0 );
			}
			displayName = newDisplayName ?? displayName;
			DebugLog( "Updating user profile" );
			DisableUI();
			return auth.CurrentUser.UpdateUserProfileAsync( new Firebase.Auth.UserProfile {
				DisplayName = displayName ,
				PhotoUrl = auth.CurrentUser.PhotoUrl ,
			} ).ContinueWith( task => {
				EnableUI();
				if( LogTaskCompletion( task , "User profile" ) ) {
					DataController.control.displayName = auth.CurrentUser.DisplayName;
					DisplayDetailedUserInfo( auth.CurrentUser , 1 );
				}
			} );
		}

		// Sign-in with an email and password.
		public Task SigninWithEmailAsync() {
			email = emailText.text;
			password = passwordText.text;
			DebugLog( String.Format( "Attempting to sign in as {0}..." , email ) );
			DisableUI();
			if( signInAndFetchProfile ) {
				return auth.SignInAndRetrieveDataWithCredentialAsync(
				  Firebase.Auth.EmailAuthProvider.GetCredential( email , password ) ).ContinueWith(
					HandleSignInWithSignInResult );
			} else {
				return auth.SignInWithEmailAndPasswordAsync( email , password )
				  .ContinueWith( HandleSignInWithUser );
			}
		}

		// This is functionally equivalent to the Signin() function.  However, it
		// illustrates the use of Credentials, which can be aquired from many
		// different sources of authentication.
		public void SigninWithEmailCredentialAsync() {
			email = emailText.text;
			password = passwordText.text;
			DebugLog( String.Format( "Attempting to sign in as {0}..." , email ) );
			DisableUI();
			if( signInAndFetchProfile ) {
				auth.SignInAndRetrieveDataWithCredentialAsync(
				 Firebase.Auth.EmailAuthProvider.GetCredential( email , password ) ).ContinueWith(
				   HandleSignInWithSignInResult );
			} else {
				auth.SignInWithCredentialAsync(
				 Firebase.Auth.EmailAuthProvider.GetCredential( email , password ) ).ContinueWith(
				   HandleSignInWithUser );
			}
			GetUserInfo();
		}

		// Attempt to sign in anonymously.
		public void SigninAnonymouslyAsync() {
			DebugLog( "Attempting to sign anonymously..." );
			DisableUI();
			auth.SignInAnonymouslyAsync().ContinueWith( HandleSignInWithUser );
		}

		public void AuthenticateToGameCenter() {
#if UNITY_IOS
        Social.localUser.Authenticate(success => {
          Debug.Log("Game Center Initialization Complete - Result: " + success);
        });
#else
			Debug.Log( "Game Center is not supported on this platform." );
#endif
		}

		public Task SignInWithGameCenterAsync() {
			var credentialTask = Firebase.Auth.GameCenterAuthProvider.GetCredentialAsync();
			var continueTask = credentialTask.ContinueWith( task => {
				if( !task.IsCompleted )
					return null;

				if( task.Exception != null )
					Debug.Log( "GC Credential Task - Exception: " + task.Exception.Message );

				var credential = task.Result;

				var loginTask = auth.SignInWithCredentialAsync( credential );
				return loginTask.ContinueWith( HandleSignInWithUser );
			} );

			return continueTask;
		}

		// Called when a sign-in without fetching profile data completes.
		void HandleSignInWithUser( Task<Firebase.Auth.FirebaseUser> task ) {
			EnableUI();
			if( LogTaskCompletion( task , "Sign-in" ) ) {
				DebugLog( String.Format( "{0} signed in" , task.Result.DisplayName ) );
			}
		}

		// Called when a sign-in with profile data completes.
		void HandleSignInWithSignInResult( Task<Firebase.Auth.SignInResult> task ) {
			EnableUI();
			if( LogTaskCompletion( task , "Sign-in" ) ) {
				DisplaySignInResult( task.Result , 1 );
			}
		}

		// Link the current user with an email / password credential.
		protected Task LinkWithEmailCredentialAsync() {
			if( auth.CurrentUser == null ) {
				DebugLog( "Not signed in, unable to link credential to user." );
				var tcs = new TaskCompletionSource<bool>();
				tcs.SetException( new Exception( "Not signed in" ) );
				return tcs.Task;
			}
			DebugLog( "Attempting to link credential to user..." );
			Firebase.Auth.Credential cred =
			  Firebase.Auth.EmailAuthProvider.GetCredential( email , password );
			if( signInAndFetchProfile ) {
				return auth.CurrentUser.LinkAndRetrieveDataWithCredentialAsync( cred ).ContinueWith(
				  task => {
					  if( LogTaskCompletion( task , "Link Credential" ) ) {
						  DisplaySignInResult( task.Result , 1 );
					  }
				  } );
			} else {
				return auth.CurrentUser.LinkWithCredentialAsync( cred ).ContinueWith( task => {
					if( LogTaskCompletion( task , "Link Credential" ) ) {
						DisplayDetailedUserInfo( task.Result , 1 );
					}
				} );
			}
		}

		// Reauthenticate the user with the current email / password.
		protected Task ReauthenticateAsync() {
			var user = auth.CurrentUser;
			if( user == null ) {
				DebugLog( "Not signed in, unable to reauthenticate user." );
				var tcs = new TaskCompletionSource<bool>();
				tcs.SetException( new Exception( "Not signed in" ) );
				return tcs.Task;
			}
			DebugLog( "Reauthenticating..." );
			DisableUI();
			Firebase.Auth.Credential cred = Firebase.Auth.EmailAuthProvider.GetCredential( email , password );
			if( signInAndFetchProfile ) {
				return user.ReauthenticateAndRetrieveDataAsync( cred ).ContinueWith( task => {
					EnableUI();
					if( LogTaskCompletion( task , "Reauthentication" ) ) {
						DisplaySignInResult( task.Result , 1 );
					}
				} );
			} else {
				return user.ReauthenticateAsync( cred ).ContinueWith( task => {
					EnableUI();
					if( LogTaskCompletion( task , "Reauthentication" ) ) {
						DisplayDetailedUserInfo( auth.CurrentUser , 1 );
					}
				} );
			}
		}

		// Reload the currently logged in user.
		public void ReloadUser() {
			if( auth.CurrentUser == null ) {
				DebugLog( "Not signed in, unable to reload user." );
				return;
			}
			DebugLog( "Reload User Data" );
			auth.CurrentUser.ReloadAsync().ContinueWith( task => {
				if( LogTaskCompletion( task , "Reload" ) ) {
					DisplayDetailedUserInfo( auth.CurrentUser , 1 );
				}
			} );
		}

		// Fetch and display current user's auth token.
		public void GetUserToken() {
			if( auth.CurrentUser == null ) {
				DebugLog( "Not signed in, unable to get token." );
				return;
			}
			DebugLog( "Fetching user token" );
			fetchingToken = true;
			auth.CurrentUser.TokenAsync( false ).ContinueWith( task => {
				fetchingToken = false;
				if( LogTaskCompletion( task , "User token fetch" ) ) {
					DebugLog( "Token = " + task.Result );
				}
			} );
		}

		// Display information about the currently logged in user.
		void GetUserInfo() {
			if( auth.CurrentUser == null ) {
				DebugLog( "Not signed in, unable to get info." );
			} else {
				DebugLog( "Current user info:" );
				DisplayDetailedUserInfo( auth.CurrentUser , 1 );
			}
		}

		// Unlink the email credential from the currently logged in user.
		protected Task UnlinkEmailAsync() {
			if( auth.CurrentUser == null ) {
				DebugLog( "Not signed in, unable to unlink" );
				var tcs = new TaskCompletionSource<bool>();
				tcs.SetException( new Exception( "Not signed in" ) );
				return tcs.Task;
			}
			DebugLog( "Unlinking email credential" );
			DisableUI();
			return auth.CurrentUser.UnlinkAsync(
			  Firebase.Auth.EmailAuthProvider.GetCredential( email , password ).Provider )
				.ContinueWith( task => {
					EnableUI();
					LogTaskCompletion( task , "Unlinking" );
				} );
		}

		// Sign out the current user.
		protected void SignOut() {
			DebugLog( "Signing out." );
			auth.SignOut();
		}

		// Show the providers for the current email address.
		protected void DisplayProvidersForEmail() {
			auth.FetchProvidersForEmailAsync( email ).ContinueWith( ( authTask ) => {
				if( LogTaskCompletion( authTask , "Fetch Providers" ) ) {
					DebugLog( String.Format( "Email Providers for '{0}':" , email ) );
					foreach( string provider in authTask.Result ) {
						DebugLog( provider );
					}
				}
			} );
		}

		// Send a password reset email to the current email address.
		protected void SendPasswordResetEmail() {
			auth.SendPasswordResetEmailAsync( email ).ContinueWith( ( authTask ) => {
				if( LogTaskCompletion( authTask , "Send Password Reset Email" ) ) {
					DebugLog( "Password reset email sent to " + email );
				}
			} );
		}
		// Cancel and go back to menu
		public void Cancel( String sceneName ) {

			SceneManager.LoadScene( sceneName );

		}
		IEnumerator ChangeScene() {
			yield return new WaitForSeconds( 3 );
			if( DataController.control.displayName != null ) {
				ToastHelper.ShowToast( "User Created Succesfully" );
			}
			yield return new WaitForSeconds( 3 );
			if(DataController.control.displayName != null) {
				SceneManager.LoadScene( "Menu" );
			}
			yield return null;
		}
	}


}
