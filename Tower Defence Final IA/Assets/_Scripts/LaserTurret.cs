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


	void FindTarget () {
		//Set the shortest distance to the longest distance possible
		float shortestDistance = Mathf.Infinity;
		//Keep track of all enemy positions in the game.
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in enemies) {
			
			float distanceBetweenEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (target == null) {
				if(distanceBetweenEnemy <= range){
				//If an enemy walks into the range of the turret target that enemy
					if (distanceBetweenEnemy < shortestDistance ) 
						target = enemy.transform;
					}
					//Only when the target is outside the range then switch to a new target
				}else if(Vector3.Distance (transform.position, target.position) > range){
					print ("HI");
					target = null;
				}
			}




		//If the current target is out of range
		//Get the closest target as target 
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

		if (target.GetInstanceID() != previousTargetID) {
			damage = startDamage;
			previousTargetID = target.GetInstanceID();
		}

	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}


}

