using UnityEngine;
using System.Collections;

public class StoreWayPoints : MonoBehaviour {

	//Credit to Brackeys for this code to essentially "hack" path finding in a tedious manner
	public static Transform[] wayPoints;

	// Use this for initialization
	void Awake () {
		wayPoints = new Transform[transform.childCount];
		for (int i = 0; i < wayPoints.Length; i++) {
			wayPoints [i] = transform.GetChild (i);
		}
	

	}

}
