using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour {

	private int wayPointIndex = 0;
	private Transform currWayPoint;
	private float maxHealth;

	[Header ("UI")]
	public int scoreAmount;
	public int moneyGained;

	[Header("Effects")]
	public GameObject deathEffect;
	public GameObject healthBar;

	[Header("Stats")]
	public float health = 100;
	public int moveSpeed = 10;
	public int damageToBase;



	void Start () {
		currWayPoint = StoreWayPoints.wayPoints [0];
		InvokeRepeating ("atBase",0f,0.1f);
		maxHealth = health;
	}


	void Update () {
		//Update the next gameObject the enemy should move towards
		currWayPoint = StoreWayPoints.wayPoints [wayPointIndex];
		//Move the gameObject
		transform.position = Vector3.MoveTowards (transform.position, currWayPoint.position, moveSpeed * Time.deltaTime);

		if(Vector3.Distance(transform.position, currWayPoint.position)<=0.2){
			getNextWayPoint();
		}

	}
		
	public void TakeDamage (float damage) {
		health -= damage;
		//change the sacle of the of the health bar to make it decrease
		healthBar.transform.localScale -= new Vector3(damage/maxHealth, 0, 0);
		if (health <= 0) {
			Dead ();
			SaveDataManager.score += scoreAmount;
			SaveDataManager.money += moneyGained;

		}
	}
	private void Dead () {
		//Destroy the gameobject
		Destroy (gameObject);
		//Play the death effect
		Instantiate (deathEffect, transform.position, Quaternion.identity); 

	}

	private void atBase () {
		//When the enemy is at the player's base, delete the enemy and decrease the player's base health
		if (wayPointIndex >= StoreWayPoints.wayPoints.Length) {
			Dead ();
			SaveDataManager.health -= damageToBase;
		}	
	}


	private void getNextWayPoint(){
		wayPointIndex++;

	}
}
