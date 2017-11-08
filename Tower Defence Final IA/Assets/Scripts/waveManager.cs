using UnityEngine;
using System.Collections;
using TMPro;

public class waveManager : MonoBehaviour {


	[System.Serializable]
	public class Wave{
		public float spawnRate;
		public int numberOfEnemies;
		public GameObject enemyType;
		public float timeBetweenNextWave;
	}
	public int initialBuildTime;
	public GameObject spawnLocation;
	public float countDownTimer;

	public TextMeshProUGUI countDownText;

	public Wave[] wave;


	private LevelManager levelManager;
	private int currentWave;
	private enum waveState {Spawning, Waiting, Coundown}
	private  waveState state;

	// Use this for initialization

	void Start () {
		levelManager = GetComponent<LevelManager> ();
		currentWave = 0;
		state = waveState.Coundown;
		countDownTimer = initialBuildTime;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWave >= wave.Length) {
			levelManager.LoadLevel ("NextLevel");
		}
		//Display countdown timer up to two decimal places
		countDownText.text = countDownTimer.ToString ("F2");
		if (countDownTimer <= 0) {
			//Reset countdown timer
			countDownTimer = wave[currentWave].timeBetweenNextWave;
			StartCoroutine(StartNextWave());
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
			SpawnEnemy (wave[currentWave].enemyType);
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
		//Create a temporary gameobject array that store any game object with the tag "enemy"
		GameObject[] numOfEnmies = GameObject.FindGameObjectsWithTag ("Enemy");

		//All enemies are dead
		if (numOfEnmies.Length <= 0) {
			isAlive = false;
			return isAlive;
		}

		isAlive = true;
		return isAlive;
	}

	void WaveComplete () {
		//Start next wave and start the countdown.
		currentWave++;
		state = waveState.Coundown;

		
	}


}
