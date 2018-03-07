using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {


	public AudioClip menuSong;
	public AudioClip gameSong;

	public static MusicPlayer mpInstance = null;
	AudioSource audioSource;
	private int sceneIndex;

	void Awake () {
		//If an Mpinstance doesn't exist
		if (mpInstance == null) {
			//set mpInstance to be the "MusicPlayer" component of this gameobject
			mpInstance = this;
			//Don't destory this gameobject duirng level changes
			DontDestroyOnLoad (this);
		} 
		else {
			//if any other instance is made destroy it.
			Destroy (gameObject);
			return;
		}
	}
	// Use this for initialization
	void Start () {
		audioSource = mpInstance.GetComponent<AudioSource> ();
		InvokeRepeating ("ChangeSong", 0, 0.1f);

	}

	void ChangeSong () {
		//Get the Scene object that the player is currently on
		Scene currentScene = SceneManager.GetActiveScene ();
		//Get the name of that scene
		string nameOfScene = currentScene.name;

		//Change an arbitrary number based on what the name of the scene contains
		if (nameOfScene.Contains("Start")) {
			sceneIndex = 0;
		}
		if (nameOfScene.Contains ("Level")) {
			sceneIndex = 1;
		}

		switch (sceneIndex) {
		case 0:
			//Check what the current track is and stop it.
			if (mpInstance.audioSource.clip == gameSong) {
				mpInstance.audioSource.clip = null;
			}
			//Play a new song
			if (mpInstance.audioSource.clip == null) {
				mpInstance.audioSource.clip = menuSong;
				mpInstance.audioSource.Play ();
			} 
			break;
		
		case 1:
			if (mpInstance.audioSource.clip == menuSong) {
				mpInstance.audioSource.clip = null;
			}
			if (mpInstance.audioSource.clip == null) {
				mpInstance.audioSource.clip = gameSong;
				mpInstance.audioSource.Play ();
			} 
			break;

		}
		
	}
}
