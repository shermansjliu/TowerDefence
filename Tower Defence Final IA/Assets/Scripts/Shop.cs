using UnityEngine;
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
		if (PlayerStats.money >= standardTurret.cost) {
			
		}
	}

	public void SelectMissileTurret () {
		currentTurret = missileTurret;
	}

	public void SelectLaserTurret () {
		if (PlayerStats.money >= laserTurret.cost) {
		}
	}





}
