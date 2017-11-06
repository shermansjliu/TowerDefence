using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;

	LineRenderer laser;
	// Use this for initialization
	void Start () {
		laser = GetComponent<LineRenderer> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		laser.SetPosition (0,startPoint.position);
		laser.SetPosition (1, endPoint.position);

	}
}
