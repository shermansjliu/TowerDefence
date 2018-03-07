using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static int levelNo = 0;

	public void LoadLevel (string name){
		SceneManager.LoadScene (name);
		if(name.Equals("Start")){
			levelNo = 0;	
		} 
	}

	public void LoadNextLevel () {
		levelNo++;
		SceneManager.LoadScene("Level " + levelNo);

	}
		
	public void QuitGame () {
		Application.Quit();
	}
		
	public void PlayAgain () {
		SceneManager.LoadScene ("Level 1");
		levelNo = 1;
	}

	public void LoseLevel() {
		SceneManager.LoadScene ("Lose Screen");
	}
	
}
