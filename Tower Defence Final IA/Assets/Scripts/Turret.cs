using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Transform target;
	public int rotationSpeed;
	public GameObject bullet;
	public GameObject fireLocation;
	public GameObject head;
	public float range;

	public int fireRate;


	// Use this for initialization
	void Start () {
	
	}

	void Update () {

	}
	
	// Update is called once per frame
	Transform findTarget () {
		//Find All enemies
		//Get Closest Enemy
		RotateTurret ();
	
	}

	void RotateTurret () {
	}

	void Fire () {
		Instantiate (bullet,fireLocation.transform.position,Rotat
	}


}
