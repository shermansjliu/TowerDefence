using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CollectBuildingBoxes ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public GameObject[] CollectBuildingBoxes () {
		GameObject[] turretlist = GameObject.FindGameObjectsWithTag ("Building Block");

	
		return turretlist;
	}
}
