﻿using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	//Helps the turretBox Script know which turretBox Gameobject it is selecting.
	public static UIManager _UImInstance;
	//private int turretBoxID;
	private int previousID;
	// Use this for initialization
	void Start () {
		//	turretBoxID = 0;
		_UImInstance = this;

	}

	public bool DifferentID (int newID) {
		if (previousID != newID) {
			return true;
		}
		return false;
	}

	public void GetID (int id){
		previousID = id;
	}

}
