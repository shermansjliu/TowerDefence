using UnityEngine;
using System.Collections;

public class waveManager : MonoBehaviour {


	[System.Serializable]
	public class Wave{
		public int spawnRate;
		public int numberOfEnemies;
		public GameObject enemyType;
	}

	public Wave[] wave;
	public float timeBetweenWaves = 3.0f;
	public GameObject spawnLocation;

	private int currentWave;
	private enum waveState {Spawning, Waiting, Coundown}
	private  waveState state;
	public float countDownTimer;

	// Use this for initialization

	void Start () {
		currentWave = 0;
		state = waveState.Coundown;
		countDownTimer = timeBetweenWaves;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (countDownTimer <= 0) {
			//Reset countdown timer
			countDownTimer = timeBetweenWaves;
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
			SpawnEnemy (wave[currentWave].enemyType);
			yield return new WaitForSeconds (1.0f / wave[currentWave].spawnRate);

		}

		state = waveState.Waiting;

		yield break;
		
	}

	void SpawnEnemy (GameObject enemy) {
		Instantiate (enemy, spawnLocation.transform.position, Quaternion.identity);
	}

	bool EnemiesStillAlive () {
		bool isAlive;
		GameObject[] numOfEnmies = GameObject.FindGameObjectsWithTag ("Enemy");
		if (numOfEnmies.Length <= 0) {
			isAlive = false;
			return isAlive;
		}

		isAlive = true;
		return isAlive;
	}

	void WaveComplete () {
		currentWave++;
		state = waveState.Coundown;

		
	}


}
