using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed;
	public GameObject deathEffect;
	public int radius;


	Transform target;
	// Use this for initialization
	public void SetTarget (Transform targetT) {
		target = targetT;
	}

	public Transform GetTarget () { 
		return target;
	}

	void FollowTarget () {
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
		if (Vector3.Distance(transform.position,target.position)<0.2f) {
			bulletDeath ();
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
		Instantiate (deathEffect,target.position,Quaternion.identity);
		
	}

	void Damage (int damage){
		// if radius > 0 do damage in radius
		//Do damage 
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			FollowTarget ();
		}


	
	}
}
