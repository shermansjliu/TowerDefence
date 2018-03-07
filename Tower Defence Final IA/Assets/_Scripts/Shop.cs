using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {



	public TurretSetup standardTurret;
	public TurretSetup missileTurret;
	public TurretSetup laserTurret;
	public TurretSetup currentTurret;

	private Dictionary<string, TurretSetup> turretTypes;  

	 
	public void Start(){
		turretTypes = new Dictionary<string, TurretSetup> ();
		turretTypes.Add ("Standard Turret", standardTurret);
		turretTypes.Add ("Missile Turret", missileTurret);
		turretTypes.Add ("Laser Turret", laserTurret);
	}

	//If the use has enough money, Buy the turret
	public TurretSetup Buy () {
		if (SaveDataManager.money >= currentTurret.cost) {
			return currentTurret;
		}
		return null;
		
	}

	//Set the user's selected turret as the turret he/she clicks on in the shop
	public	void SelectStandardTurret () {
		currentTurret = turretTypes["Standard Turret"];
	}

	public void SelectMissileTurret () {
		currentTurret = turretTypes["Missile Turret"];
	}

	public void SelectLaserTurret () {
		currentTurret = turretTypes["Laser Turret"];
		
	}

	//Deduct money from the player's account
	public void SpendMoney (TurretSetup selectedTurret){
		SaveDataManager.money -= selectedTurret.cost;
		
	}







}
