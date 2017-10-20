using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public ParticleSystem effect;
	public Transform target;
	public int speed;

	private Turret turret;


	// Use this for initialization
	void Start () {
		turret = GetComponent<Turret> ();
		
	}

	void followTarget () {
		
		
	}

	void bulletDeath () {
	}
	
	// Update is called once per frame
	void Update () {
		if (turret.target != null) {
			target = turret.target;
		}


	
	}
}
