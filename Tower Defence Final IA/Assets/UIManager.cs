using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public static UIManager _UImInstance;
	private int turretBoxID;

	// Use this for initialization
	void Start () {
		turretBoxID = 0;
		_UImInstance = this;

	}

	public bool DifferentID (int id) {
		if (turretBoxID != id) {
			return true;
		}
		return false;
	}

	public void GetID (int id){
		turretBoxID = id;
	}

}
