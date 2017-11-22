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
		PlayerPrefs.DeleteKey (SaveDataManager.saveDataInstance.key);
	}

	public void SetCurrentScore () {
		int finalScore = SaveDataManager.score + SaveDataManager.money * 3 ;
		if(currentScore.text != null)
			currentScore.text = "Score: " + finalScore;
	}

	public void SetHighScore () {
		if(highScore.text != null)
			highScore.text = "Highscore: " + PlayerPrefs.GetInt(SaveDataManager.saveDataInstance.key);
	}
}
