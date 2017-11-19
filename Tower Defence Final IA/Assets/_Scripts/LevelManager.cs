using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static int levelNo = 0;

	public void LoadLevel (string name){
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene("Level " + levelNo);
		levelNo++;
	}
		
	public void QuitGame () {
		Application.Quit();
	}
}
