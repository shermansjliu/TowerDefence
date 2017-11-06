using UnityEngine;
using System.Collections;


public class LaserTurret : MonoBehaviour {

	[Header("Universal Settings")]
	//For Debugging puproses
	public Transform target;
	//Control Rotation speed of the turret
	public GameObject fireLocation;
	//Makes sure that only the head of the turret rotates.
	public GameObject partThatRotates;
	//Stores the range of the turret
	public float range;
	//Stores the shortestDistance between an enemy and the turret to make it its target
	public float rotationSpeed;
	public float rotationUntilFire;
	public float damage;


	float shortestDistance; 

	//Stores fireRate
	[Header("Laser Settings")]
	public float damageMultiplier;
	private float startDamage;
	private int previousTargetID;
	LineRenderer laserLine;





	// Use this for initialization
	void Start () {
		previousTargetID = 0;
		startDamage = damage;
		laserLine = GetComponent<LineRenderer> ();
		//InvokeRepeating is used as a method to be called from a certain point in the game every certain numer of seconds
		//Used to optimise performance because less calls.
		InvokeRepeating ("FindTarget", 0, 0.2f);
	}

	//Updates the turret rotation and firerate 60 frames a second
	void Update () {
		if (target != null) {
			RotateTurret ();
		} else {
			DisableLaser ();
		}
	}

	// Update is called once per frame

	//Updates the turret's "current target"
	void FindTarget () {
		//By default whent here is no enemy
		float shortestDistance = Mathf.Infinity;
		//Find All enemies
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
		//Get Vector3 of Closest Enemy
		//For every enemy in targets array
		foreach (GameObject enemy in targets) {
			//If distance between the turret and the target is less than the current shortestDistance
			float distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (distance < shortestDistance) {
				//Make the shortestDistance equal to the new shortestDistance
				shortestDistance = distance;

				//if the shortest distance is within the turret range
				if (shortestDistance <= range) {
					//Make the targget the position of the enemy
					target = enemy.transform;
				} else {
					//Else there should be no target
					target = null;	
					//Reset damage 
				

				}
			}
		}

	}
	//Rotate towards closest enemy if the target is within range
	void RotateTurret () {
		//Retrieve direction towards the enemy
		Vector3 directionToEnemy = (target.position - transform.position).normalized;
		//Calculate the rotation needed to look towards the target
		Quaternion targetRotation = Quaternion.LookRotation (directionToEnemy);
		targetRotation.x = 0;
		targetRotation.z = 0;
		//Interpolates the amount needed to rotate the turret. This is used to smoothen the rotation and make sure the rotation is constant
		partThatRotates.transform.rotation = Quaternion.Lerp (partThatRotates.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		//Check that angle difference < 15 before firing projectile
		if (Quaternion.Angle (partThatRotates.transform.rotation, targetRotation) <= rotationUntilFire) {
			Fire ();
		} else {
			DisableLaser ();
		}


	}

	void DisableLaser() {
		laserLine.enabled = false;
	}

	void Fire () {
		//Fire Laser towards target
		laserLine.enabled = true;
		laserLine.SetPosition(0,fireLocation.transform.position);
		laserLine.SetPosition (1, target.position);
		DamagePerSecond ();
	}

	void DamagePerSecond () {
		target.GetComponent<EnemyProperties> ().TakeDamage (damage * Time.deltaTime);
		damage *= damageMultiplier;

		print (target.Equals (target));
		if (target.GetInstanceID() != previousTargetID || target == null) {
			damage = startDamage;
			previousTargetID = target.GetInstanceID();
		}

	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}


}

