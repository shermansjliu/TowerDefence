using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {

	public float spawnRate;
	public int numberOfEnemies;
	public GameObject[] enemyType;
	public float timeBetweenNextWave;
	public int scoreAmount;
}
