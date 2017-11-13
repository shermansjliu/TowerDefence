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
		Scene currentScene = SceneManager.GetActiveScene ();
		string nameOfScene = currentScene.name;


		if (nameOfScene.Contains("Start")) {
			sceneIndex = 0;
		}
		if (nameOfScene.Contains ("Level")) {
			sceneIndex = 1;
		}

		switch (sceneIndex) {
		case 0:
			if (mpInstance.audioSource.clip == gameSong) {
				mpInstance.audioSource.clip = null;
			}
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
