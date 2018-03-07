using UnityEngine;
using System.Collections;


public class Turret : MonoBehaviour {

	//For Debugging puproses
	public Transform target;
	//Control Rotation speed of the turret
	public int rotationSpeed;
	//stores the bullet gameobject that will be used
	public GameObject bullet;
	//Stores the instantiation location of the bullet
	public GameObject fireLocation;
	//Makes sure that only the head of the turret rotates.
	public GameObject partThatRotates;
	//Stores the range of the turret
	public float range;
	//Stores fireRate
	public float fireRate;



	private float fireTimer = 0;
	//Stores the shortestDistance between an enemy and the turret to make it its target
	private float shortestDistance; 



	// Use this for initialization
	void Start () {
		//InvokeRepeating is used as a method to be called from a certain point in the game every certain numer of seconds
		//Used to optimise performance because less calls.
		InvokeRepeating ("FindTarget", 0, 0.2f);
	}

	//Updates the turret rotation and firerate 60 frames a second
	void Update () {
		if (target != null) {
			RotateTurret ();

		}
		fireTimer -= Time.deltaTime;
	}

	//Updates the “target” variable, which is of type “transform”
	void FindTarget () {
		//Set the shortest distance to a really long distance in order to guarantee a shorter distance 
		float shortestDistance = 9999999999;
		//Store all Gameobjects with the tag “Enemy” in an array
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

		//Set the turrets target
		foreach (GameObject enemy in targets) {
			//If distance between the turret and the target is less than the current shortestDistance
			float distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (distance < shortestDistance) {
				//Make the shortestDistance equal to the new shortestDistance
				shortestDistance = distance;
				//if the shortest distance is within the turret range
				if (shortestDistance <= range) {
					//Make the target of the turret the transform property of the enemy game object 
					target = enemy.transform;
				} else {
					//Else there should be no target
					target = null;	
				}
			}
		}

	}
	//IF the target is within range rotate the turret towards it
	void RotateTurret () {
		//Retrieve direction towards the enemy
		Vector3 directionToEnemy = (target.position - transform.position).normalized;
		/*Calculate the rotation needed to look towards the target (A Quaternion is used to prevent gimbal lock. 
		//Though it won’t occur in this instance, it is just good practice*/
		Quaternion targetRotation = Quaternion.LookRotation (directionToEnemy);
		targetRotation.x = 0;
		targetRotation.z = 0;
		//Interpolate the amount needed to rotate the turret. This is used to smoothout the rotation and make sure the rotation speed is constant
		//Rotate the partThatRotates gameobject (The head of the turret) 
		partThatRotates.transform.rotation = Quaternion.Lerp (partThatRotates.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		/*Check that angle difference is small enough (<= 25) before firing projectile) 
		(so that the turret head is somewhat pointing towards the enemy before it fires*/
		if(Quaternion.Angle(partThatRotates.transform.rotation,targetRotation) <= 25) {
			if (fireTimer <= 0 ) {
				Fire ();
			}
		}
	

	}
		

	void Fire () {
		//Instantiate a Bullet prefab. 
		//This temporary reference and cast to a game object in order to call the “setTarget” method inside the “Bullet Script” of the instantiated bullet 
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

