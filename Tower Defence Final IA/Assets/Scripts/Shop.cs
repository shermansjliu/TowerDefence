﻿using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {


	public TurretSetup standardTurret;
	public TurretSetup missileTurret;
	public TurretSetup laserTurret;
	public TurretSetup currentTurret;

	// Use this for initialization

		

	
	// Update is called once per frame

	public TurretSetup Buy () {
		if (PlayerStats.money >= currentTurret.cost) {
			return currentTurret;
		}
		return null;
		
	}

	public	void SelectStandardTurret () {
		currentTurret = standardTurret;
	}

	public void SelectMissileTurret () {
		currentTurret = missileTurret;
	}

	public void SelectLaserTurret () {
		currentTurret = laserTurret;
		
	}

	public void BuyTurret (TurretSetup selectedTurret) {
		PlayerStats.money -= selectedTurret.cost;
		
	}




}