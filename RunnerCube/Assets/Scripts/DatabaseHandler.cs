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

namespace Firebase.Sample.Database {
	using Firebase;
	using Firebase.Database;
	using Firebase.Unity.Editor;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.SceneManagement;

	// Handler for UI buttons on the scene.  Also performs some
	// necessary setup (initializing the firebase app, etc) on
	// startup.
	public class DatabaseHandler:MonoBehaviour {
		public Text scoreText;
		public Text nameText;
		public Text leaderBoardText;
		ArrayList leaderBoard = new ArrayList();
		private const int MaxScores = 10;
		private string logText = "";
		private string email = "";
		private int score = 100;
		protected Firebase.Auth.FirebaseAuth auth;
		const int kMaxLogSize = 16382;
		DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
		protected bool isFirebaseInitialized = false;

		// When the app starts, check to make sure that we have
		// the required dependencies to use Firebase, and if not,
		// add them if possible.
		protected virtual void Start() {
			auth = GameObject.FindGameObjectWithTag( "Auth" ).GetComponent<Auth.AuthHandler>().ReturnAuth();
			if( auth.CurrentUser != null ) {
				nameText.text = auth.CurrentUser.DisplayName;
				email = auth.CurrentUser.Email;
				RetriveUserScore();
			} else {
				nameText.text = "Must be logged in to submit score";
			}
			scoreText.text = DataController.control.bestScore;
			//nameText.text = DataController.control.displayName;
			leaderBoard.Clear();
			leaderBoard.Add( "" );
			FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( task => {
				dependencyStatus = task.Result;
				if( dependencyStatus == DependencyStatus.Available ) {
					InitializeFirebase();
				} else {
					Debug.LogError(
					  "Could not resolve all Firebase dependencies: " + dependencyStatus );
				}
			} );
		}

		// Initialize the Firebase database:
		protected virtual void InitializeFirebase() {
			FirebaseApp app = FirebaseApp.DefaultInstance;
			// NOTE: You'll need to replace this url with your Firebase App's database
			// path in order for the database connection to work correctly in editor.
			app.SetEditorDatabaseUrl( "https://runnercube-dgs.firebaseio.com/" );
			if( app.Options.DatabaseUrl != null )
				app.SetEditorDatabaseUrl( app.Options.DatabaseUrl );
			StartListener();
			isFirebaseInitialized = true;
		}

		protected void StartListener() {
			FirebaseDatabase.DefaultInstance
			  .GetReference( "Leaders" ).OrderByChild( "score" )
			  .ValueChanged += ( object sender2 , ValueChangedEventArgs e2 ) => {
				  if( e2.DatabaseError != null ) {
					  Debug.LogError( e2.DatabaseError.Message );
					  return;
				  }
				  Debug.Log( "Received values for Leaders." );
				  string title = leaderBoard[0].ToString();
				  leaderBoard.Clear();
				  leaderBoard.Add( title );
				  if( e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0 ) {
					  foreach( var childSnapshot in e2.Snapshot.Children ) {
						  if( childSnapshot.Child( "score" ) == null
					|| childSnapshot.Child( "score" ).Value == null ) {
							  Debug.LogError( "Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?" );
							  break;
						  } else {
							  Debug.Log( "Leaders entry : " +
							 childSnapshot.Child( "name" ).Value.ToString() + " - " +
							 childSnapshot.Child( "score" ).Value.ToString() );
							  leaderBoard.Insert( 1 , childSnapshot.Child( "score" ).Value.ToString()
							  + "  " + childSnapshot.Child( "name" ).Value.ToString() );
							  // setear el leaderboard y updatearlo cuando cambia
							  leaderBoardText.text = "";
							  foreach( string item in leaderBoard ) {
								  Debug.Log( item );
								  leaderBoardText.text += "\n" + item;
							  }
						  }
					  }
				  }
			  };
		}

		// Exit if escape (or back, on mobile) is pressed.
		protected virtual void Update() {
			if( Input.GetKeyDown( KeyCode.Escape ) ) {
				Application.Quit();
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

		// A realtime database transaction receives MutableData which can be modified
		// and returns a TransactionResult which is either TransactionResult.Success(data) with
		// modified data or TransactionResult.Abort() which stops the transaction with no changes.
		TransactionResult AddScoreTransaction( MutableData mutableData ) {
			Dictionary<string , object> leaders = mutableData.Value as Dictionary<string , object>;

			if( leaders == null ) {
				leaders = new Dictionary<string , object>();
			}
			if( leaders.ContainsKey( auth.CurrentUser.UserId ) ) {
				Dictionary<string , object> ExistScoreMap = leaders[auth.CurrentUser.UserId] as Dictionary<string , object>;
				ExistScoreMap["score"] = score;
				ExistScoreMap["name"] = auth.CurrentUser.DisplayName;
				ExistScoreMap["email"] = auth.CurrentUser.Email;
				leaders[auth.CurrentUser.UserId] = ExistScoreMap;
			} else {

				// Now we add the new score as a new entry that contains the email address and score.
				Dictionary<string , object> newScoreMap = new Dictionary<string , object>();
				newScoreMap["score"] = score;
				newScoreMap["name"] = auth.CurrentUser.DisplayName;
				newScoreMap["email"] = auth.CurrentUser.Email;
				leaders.Add( auth.CurrentUser.UserId , newScoreMap );
			}


			// You must set the Value to indicate data at that location has changed.
			mutableData.Value = leaders;
			return TransactionResult.Success( mutableData );
		}


		public void AddScore() {
			score = Int32.Parse( scoreText.text );
			email = nameText.text;
			if( score == 0 || auth.CurrentUser == null ) {
				DebugLog( "invalid score or user not logged in." );
				return;
			}
			DebugLog( String.Format( "Attempting to add score {0} {1}" ,
			  email , score.ToString() ) );

			DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference( "Leaders" );

			DebugLog( "Running Transaction..." );
			// Use a transaction to ensure that we do not encounter issues with
			// simultaneous updates that otherwise might create more than MaxScores top scores.
			reference.RunTransaction( AddScoreTransaction )
			  .ContinueWith( task => {
				  if( task.Exception != null ) {
					  DebugLog( task.Exception.ToString() );
				  } else if( task.IsCompleted ) {
					  DebugLog( "Transaction complete." );
				  }
			  } );
		}
		//Load Scenes
		public void LoadScene( string sceneName ) {
			SceneManager.LoadScene( sceneName );
		}
		public void RetriveUserScore() {
			FirebaseDatabase.DefaultInstance.GetReference( auth.CurrentUser.UserId ).GetValueAsync().ContinueWith((task)=> {
				if( task.IsFaulted ) {
					// Handle the error...
				} else if( task.IsCompleted ) {
					DataSnapshot snapshot = task.Result;
					// Do something with snapshot...
					score = (int)snapshot.Child( "score" ).Value;
					scoreText.text = score.ToString();
				}
			});
		}
	}
}