using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {


	public TurretSetup standardTurret;
	public TurretSetup missileTurret;
	public TurretSetup laserTurret;
	public TurretSetup currentTurret;

	public bool isCurrTurr;

	// Use this for initialization


	void Start(){
		
	}

	
	// Update is called once per frame

	public TurretSetup Buy () {
		if (PlayerStats.money >= currentTurret.cost) {
			isCurrTurr = true;
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

	public void SpendMoney (TurretSetup selectedTurret){
		PlayerStats.money -= selectedTurret.cost;
		
	}







}
