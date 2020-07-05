using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController:MonoBehaviour {
	public static DataController control;
	public string email;
	public string password;
	public string displayName;
	public string bestScore;
	public bool mute;
	public bool cambioSonido;
	public bool isPlaying;
	private void Awake() {
		if( control == null ) {
			DontDestroyOnLoad( gameObject );
			control = this;
			bestScore = "0";
		} else if( control != this ) {
			Destroy( gameObject );
		}
	}
	private void Update() {
		MutePlaying();
	}
	private void OnEnable() {
		Load();
	}
	private void OnDisable() {
		Save();
	}
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create( Application.persistentDataPath + "/PlayerInfo.dat" );
		PlayerData data = new PlayerData();
		data.email = email;
		data.password = password;
		data.displayName = displayName;
		data.bestScore = bestScore;
		bf.Serialize( file , data );
		file.Close();
	}
	public void Load() {
		if( File.Exists( Application.persistentDataPath + "/PlayerInfo.dat" ) ) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open( Application.persistentDataPath + "/PlayerInfo.dat" , FileMode.Open );
			PlayerData data = (PlayerData)bf.Deserialize( file );
			file.Close();
			email = data.email;
			password = data.password;
			displayName = data.displayName;
			data.bestScore = bestScore;
		}
	}
	public void Mute() {
		if( mute ) {
			mute = false;

		} else {
			mute = true;
		}
		cambioSonido = true;
	}
	public void MutePlaying() {
		if( SceneManager.GetActiveScene().name == "Main" ) {
			GetComponent<AudioSource>().mute = true;
		}else if( SceneManager.GetActiveScene().name == "GameOver" ) {

			if( mute ) {
				GetComponent<AudioSource>().mute = true;
				isPlaying = true;
			} else {
				GetComponent<AudioSource>().mute = false;
				if( GetComponent<AudioSource>().clip.name != "GameOver" ) {
					GetComponent<AudioSource>().Stop();
					GetComponent<AudioSource>().clip = Resources.Load<AudioClip>( "GameOver" );
					GetComponent<AudioSource>().Play();
				}
			}

		} else {
			if( mute ) {
				GetComponent<AudioSource>().mute = true;
				isPlaying = true;
			} else {
				GetComponent<AudioSource>().mute = false;
				if( GetComponent<AudioSource>().clip.name != "MenuPrincipal" ) {
					GetComponent<AudioSource>().Stop();
					GetComponent<AudioSource>().clip = Resources.Load<AudioClip>( "MenuPrincipal" );
					GetComponent<AudioSource>().Play();
				}
			}

		}
	}
}
[Serializable]
class PlayerData {
	public string email;
	public string password;
	public string displayName;
	public string bestScore;
}
