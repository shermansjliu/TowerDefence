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
	public float fireRate;
	private float fireTimer = 0;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("FindTarget", 0, 0.2f);
	}

	void Update () {
		if (target != null) {
			RotateTurret ();

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
		Vector3 directionToEnemy = (target.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.LookRotation (directionToEnemy);
		targetRotation.x = 0;
		targetRotation.z = 0;
		partThatRotates.transform.rotation = Quaternion.Lerp (partThatRotates.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		//Check that angle difference < 15 before firing projectile
		if(Quaternion.Angle(partThatRotates.transform.rotation,targetRotation) <= 20) {
			if (fireTimer <= 0 ) {
				Fire ();
			}
		}
	

	}
		

	void Fire () {
		//Change Call script of instantiated object
		GameObject bulletFiredGO = (GameObject) Instantiate (bullet, fireLocation.transform.position, partThatRotates.transform.rotation);
		//Calling setTarget of BulletfiredGo script
		Bullet bulletScript = bulletFiredGO.GetComponent<Bullet> ();
		bulletScript.SetTarget (target);
		fireTimer = 1.0f / fireRate;

	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}


}

