using UnityEngine;
using System.Collections;
using TMPro;



public class ScoreManager : MonoBehaviour {
	public TextMeshProUGUI currentScore = null;
	public TextMeshProUGUI highScore = null;

	void Start(){
		InvokeRepeating ("SetCurrentScore", 0, 0.2f);
		InvokeRepeating ("SetHighScore", 0, 0.2f);
	}

	public void ResetHighScore ()	{
		PlayerPrefs.DeleteKey (SaveDataManager.key);
		Debug.Log(PlayerPrefs.GetInt( SaveDataManager.key));
	}

	public void SetCurrentScore () {
		int finalScore = SaveDataManager.score + SaveDataManager.money * 3 ;
		if(currentScore != null)
			currentScore.text = "Score: " + finalScore;
		else {
			return;
		}
	}

	public void SetHighScore () {
		if (highScore != null) {
			print (PlayerPrefs.GetInt ("Highscore"));

			highScore.text = "Highscore: " + PlayerPrefs.GetInt (SaveDataManager.key);
		}else {
			return;

		}
	}
}
