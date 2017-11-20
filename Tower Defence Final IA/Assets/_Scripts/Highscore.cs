using UnityEngine;
using System.Collections;
using TMPro;

public class Highscore : MonoBehaviour {

	public TextMeshProUGUI highsScore;
	// Use this for initialization
	void Start () {
		highsScore.text = "Score: "+SaveDataManager.score;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
