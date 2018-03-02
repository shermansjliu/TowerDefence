using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class waveManager : MonoBehaviour {

	public int initialBuildTime;
	public GameObject spawnLocation;
	public float countDownTimer;

	public TextMeshProUGUI waveNumberText;
	public TextMeshProUGUI countDownText;

	public Wave[] wave;


	public LevelManager levelManager;
	private int waveNum;
	private int currentWave;
	private enum waveState {Spawning, Waiting, Coundown}
	private  waveState state;

	// Use this for initialization

	void Start () {
		currentWave = 0;
		waveNum = 1;
		state = waveState.Coundown;
		countDownTimer = initialBuildTime;
		waveNumberText.text = "" + waveNum + "/" + wave.Length;
	}

	void Update () {
		//Skip the countdown timer if user hits "Return"
		if (Input.GetKeyDown (KeyCode.Return)) {
			Skip ();
		}
		//Load the next wevel once all the waves have been iterated through
		if (waveNum > wave.Length){
			levelManager.LoadLevel ("NextLevel");
		//Once level three has ended load the "Win screen"
			if (LevelManager.levelNo > 3)
				levelManager.LoadLevel ("Win Screen");
		}
		//Display countdown timer up to two decimal places
		countDownText.text = countDownTimer.ToString ("F2");
		//If the wave timer is 0 and the last wave has not been reached
		if (countDownTimer <= 0 && waveNum <= wave.Length) {
			//Reset countdown timer to 0
			countDownTimer = wave [currentWave].timeBetweenNextWave;
		//Start the next wave
			StartCoroutine (StartNextWave ());
		} 
		//If enemies are no longer alive the wave is complete
		if (state == waveState.Waiting) {
			if (!EnemiesStillAlive ()) {
				WaveComplete ();

			} else {
				return;
			}
		}
		//Decrease the countdown
		if (state == waveState.Coundown) {
			countDownTimer -= Time.deltaTime;
		}

	}

	void Skip () {
		if (state != waveState.Coundown) {
			//If wave is counting down render this function useless
			return;
			//If the user hits return make the counter 0
		}else{
			countDownTimer = 0;
		}
	}

	//Spawn next wave
	IEnumerator StartNextWave () {
		//The wave is now spawning
		state = waveState.Spawning;
		//
		for (int i = 0; i < wave[currentWave].numberOfEnemies; i++) {
			//Spawn an enemy based on the random enemy generated
			SpawnEnemy (wave[currentWave].enemyType[Random.Range(0,wave[currentWave].enemyType.Length)]);
			//Make sure that an enemy only spawns after the spawnrate timer is done
			yield return new WaitForSeconds (1.0f / wave[currentWave].spawnRate);

		}
		//Set the state of the "wave" to waiting
		state = waveState.Waiting;

		yield break;
		
	}

	void SpawnEnemy (GameObject enemy) {
		//Instantate the passed in enemy game object at a spawn location and rotation 
		Instantiate (enemy, spawnLocation.transform.position, Quaternion.identity);
	}

	//Check if enemies are alive, return true if there are enemies, return false if they're no enemies
	bool EnemiesStillAlive () {
		bool isAlive;
	
		//numEnemies = GameObject.FindGameObjectsWithTag ("Enemy");

		//Create a temporary gameobject array that store any game object with the tag "enemy"
		GameObject[] numOfEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
			
		//All enemies are dead
		if (numOfEnemies.Length <= 0) {
			isAlive = false;
			return isAlive;
		}

		isAlive = true;
		return isAlive;
	}

	void WaveComplete () {
		//Start next wave and start the countdown.
		currentWave++;
		waveNum++;
		waveNumberText.text = "" +  waveNum + "/" + wave.Length;
		state = waveState.Coundown;
		SaveDataManager.score += wave[currentWave].scoreAmount;
		
	}


}
