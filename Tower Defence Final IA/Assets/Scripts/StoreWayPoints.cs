using UnityEngine;
using System.Collections;

public class StoreWayPoints : MonoBehaviour {

	public static Transform[] wayPoints;

	// Use this for initialization
	void Awake () {
		wayPoints = new Transform[transform.childCount];
		for (int i = 0; i < wayPoints.Length; i++) {
			wayPoints [i] = transform.GetChild (i);
		}
	

	}

}
