using UnityEngine;
using System.Collections;


public class Turret : MonoBehaviour {

	public Transform target;
	public int rotationSpeed;
	public GameObject bullet;
	public GameObject fireLocation;
	public GameObject partThatRotates;
	public float range;
	float shortestDistance; 
	public int fireRate;
	private float fireTimer;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("FindTarget", 0, 0.2f);
	}

	void Update () {
		if (target != null) {
			RotateTurret ();
			if (fireTimer <= 0) {
				Fire ();
			}
		}
		fireTimer -= Time.deltaTime;
	}

	// Update is called once per frame
	void FindTarget () {
		float shortestDistance = Mathf.Infinity;
		//Find All enemies
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
		//Get Closest Enemy

		foreach (GameObject enemy in targets) {
			float distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (distance < shortestDistance) {
				shortestDistance = distance;

				if (shortestDistance <= range) {
					target = enemy.transform;
				} else {
					target = null;	
				}
			}
		}
		//Rotate towards closest enemy if the target is within range
	}

	void RotateTurret () {
		Vector3 directionToEnemy = (target.position - transform.position);
		Quaternion targetRotation = Quaternion.LookRotation (directionToEnemy);
		targetRotation.x = 0;
		targetRotation.z = 0;
		partThatRotates.transform.rotation = Quaternion.Slerp (partThatRotates.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	

	}
		

	void Fire () {
		//fireTimer = 1/fireRate;
		fireTimer = 30.0f;
		Instantiate (bullet, fireLocation.transform.position, partThatRotates.transform.rotation);
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}


}

