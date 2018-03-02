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
		currWayPoint = StoreWayPoints.wayPoints [wayPointIndex];
		transform.position = Vector3.MoveTowards (transform.position, currWayPoint.position, moveSpeed * Time.deltaTime);

		if(Vector3.Distance(transform.position, currWayPoint.position)<=0.2){
			getNextWayPoint();
		}

	}
		
	public void TakeDamage (float damage) {
		health -= damage;
		healthBar.transform.localScale -= new Vector3(damage/maxHealth, 0, 0);
		if (health <= 0) {
			Dead ();
			SaveDataManager.score += scoreAmount;
			SaveDataManager.money += moneyGained;

		}
	}
	private void Dead () {
		Destroy (gameObject);
		Instantiate (deathEffect, transform.position, Quaternion.identity); 

	}

	private void atBase () {
		if (wayPointIndex >= StoreWayPoints.wayPoints.Length) {
			Dead ();
			SaveDataManager.health -= damageToBase;
		}	
	}


	private void getNextWayPoint(){
		wayPointIndex++;

	}
}
