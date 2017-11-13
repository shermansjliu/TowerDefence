using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public Canvas pauseMenu;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1 && pauseMenu.gameObject.activeInHierarchy == false) {
				pauseMenu.gameObject.SetActive (true);	
				MusicPlayer.mpInstance.GetComponent<AudioSource> ().Pause ();
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
				pauseMenu.gameObject.SetActive (false);
				MusicPlayer.mpInstance.GetComponent<AudioSource> ().UnPause ();
			}
		}
	}
}
