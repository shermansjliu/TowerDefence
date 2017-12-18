using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class waveManager : MonoBehaviour {


	[System.Serializable]
	public class Wave{
		public float spawnRate;
		public int numberOfEnemies;
		public GameObject[] enemyType;
		public float timeBetweenNextWave;
		public int scoreAmount;
	}
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
	
	// Update is called once per frame
	void Update () {
		
		if (waveNum > wave.Length) {
			levelManager.LoadLevel ("NextLevel");
			if (LevelManager.levelNo > 3)
				levelManager.LoadLevel ("Win Screen");
		}
		//Display countdown timer up to two decimal places
		countDownText.text = countDownTimer.ToString ("F2");
		if (countDownTimer <= 0 && waveNum <= wave.Length) {
			//Reset countdown timer
			countDownTimer = wave [currentWave].timeBetweenNextWave;
			StartCoroutine (StartNextWave ());
		} 

		if (state == waveState.Waiting) {
			if (!EnemiesStillAlive ()) {
				WaveComplete ();

			} else {
				return;
			}
		}
		if (state == waveState.Coundown) {
			countDownTimer -= Time.deltaTime;
		}

	}

	IEnumerator StartNextWave () {
		//Start spawning wave
		state = waveState.Spawning;
		for (int i = 0; i < wave[currentWave].numberOfEnemies; i++) {
			//Spawn one instance of an enemy if i < the number of enemies integer
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
	

		List<GameObject> numEnemies = new List<GameObject>();

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
