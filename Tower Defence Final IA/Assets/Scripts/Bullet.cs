using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed;
	public GameObject deathEffect;
	public int radius;
	public float damageAmount;




	Transform target;
	// Use this for initialization
	public void SetTarget (Transform targetT) {
		target = targetT;
	}
		

	void FollowTarget () {
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
		if (Vector3.Distance(transform.position,target.position)<0.5f || target == null) {
			bulletDeath ();
			DoDamage ();

		}
		RotateBullet ();

	}

	void RotateBullet () {
		//Update Rotation of Missile
		Vector3 rotationDir = target.position - transform.position;
		Quaternion actualRotation = Quaternion.LookRotation (rotationDir);
		actualRotation.x = 0;
		actualRotation.z = 0;
		transform.rotation = Quaternion.Slerp (transform.rotation, actualRotation, 5*Time.deltaTime);
	}


	void bulletDeath () {
		Destroy (gameObject);
		GameObject deathEffectClone = (GameObject)Instantiate(deathEffect,target.position,Quaternion.identity);
		Destroy (deathEffectClone, 0.8f);
	}

	void DoDamage () {
		if (radius > 0) {
			AOEDamage (transform.position, radius);
		} else {
			target.GetComponent<EnemyProperties> ().TakeDamage (damageAmount);
		}
	}
	int enemyCount = 0;
	void AOEDamage (Vector3 position, float radius) {
		//Stores all detected gameobjects with a collider component into an list because lists have explicit types
		Collider[] EnemieswithinRange = Physics.OverlapSphere (position, radius);
		//Detect every game object inside the array
		foreach (Collider col in EnemieswithinRange) {
			//If the game object has an "Enemy" Tag
			if(col.CompareTag("Enemy")) {
				//Declare a type EnemyProperties variable that refres to the "EnemyProperties" scripts
				EnemyProperties enemyHit = col.GetComponent<EnemyProperties> ();
				//call the method of standard enemy to deal damage to enemy
				enemyHit.TakeDamage (damageAmount);
				enemyCount++;
			}
		}
	}


	void OnDrawGizmosSelected () {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, radius);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			FollowTarget ();
		}
		//Destroy game object if the target is no longer there (so that there are no bullets that are left mid air with no target)
		if (target == null) {
			Destroy (gameObject);
		}

	
	}
}
