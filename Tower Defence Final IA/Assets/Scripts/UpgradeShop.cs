using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class UpgradeShop : MonoBehaviour {



	[Header("Standard Upgrades")]
	public TurretSetup[] upgradeSTurr;
	[Header("Missile Upgrades")]
	public TurretSetup[] upgradeMTurr;
	[Header("Laser Upgrades")]
	public TurretSetup[] upgradeLTurr;

	bool isUISelected;
	TurretBox turretBox;


	// Use this for initialization


	void Start () {
		turretBox = GetComponentInParent<TurretBox> ();


	}

	// Update is called once per frame
	void Update () {
	
	}

	public void findTurretType () {
		//print (upgradeSTurr [0]);
		if (turretBox.selectedTurret.prefab.name.Contains("Standard")){
			//if (upgradeSTurr [0].cost <= PlayerStats.money) {
			//}

			turretBox.UpgradeCurrentTurret (upgradeSTurr);
		}
			
	}

	public void SellTurret () {
		turretBox.SellCurrentTurret ();
	}









}
