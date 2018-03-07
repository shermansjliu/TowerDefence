using UnityEngine;
using System.Collections;

public class DeveloperTools : MonoBehaviour {

	void Start(){
		print ("Level Number: " + LevelManager.levelNo);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J) && Input.GetKeyDown (KeyCode.Slash)) {
			SaveDataManager.money += 1000;
		}
	
	}
}
