using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour {

	private int wayPointIndex = 0;
	private Transform currWayPoint;
	private float maxHealth;

	public float health = 100;
	public int moveSpeed = 10;
	public GameObject deathEffect;
	public GameObject healthBar;
	public int moneyGained;
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
			PlayerStats.money += moneyGained;

		}
	}

	public void TakeAreaDamage (float damage, float radius, Vector3 position){
		TakeDamage (damage);
	}

	void Dead () {
		Destroy (gameObject);
		Instantiate (deathEffect, transform.position, Quaternion.identity); 
	}

	void atBase () {
		if (wayPointIndex >= StoreWayPoints.wayPoints.Length) {
			Dead ();
			PlayerStats.health -= damageToBase;
		}	
	}


	private void getNextWayPoint(){
		wayPointIndex++;

	}
}
