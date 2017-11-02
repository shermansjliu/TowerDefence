using UnityEngine;
using System.Collections;

public class StandardEnemy : MonoBehaviour {

	private int wayPointIndex = 0;
	private Transform currWayPoint;

	public float health = 100;
	public int moveSpeed = 10;
	public GameObject deathEffect;



	void Start () {
		currWayPoint = StoreWayPoints.wayPoints [0];
		InvokeRepeating ("atBase",0f,0.1f);
		

	}


	void Update () {
		currWayPoint = StoreWayPoints.wayPoints [wayPointIndex];
		transform.position = Vector3.MoveTowards (transform.position, currWayPoint.position, moveSpeed * Time.deltaTime);
		if (health <= 0) {
			
		}


		if(Vector3.Distance(transform.position, currWayPoint.position)<=0.2){
			getNextWayPoint();
		}

	}
		
	public void TakeDamage (float damage) {
		health -= damage;
		if (health <= 0) {
			Dead ();
		}
	}

	public void TakeAreaDamage (float damage, float radius, Vector3 position){
		TakeDamage (damage);
	}

	void Dead () {
		Destroy (gameObject);
		wayPointIndex = 0;
	}

	void atBase () {
		if (wayPointIndex >= StoreWayPoints.wayPoints.Length) {
			Dead ();
		}	
	}


	private void getNextWayPoint(){
		wayPointIndex++;

	}
}
