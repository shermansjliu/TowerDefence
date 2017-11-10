using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;
public class UpgradeShop : MonoBehaviour {



	public TextMeshProUGUI upgradePriceText;
	public TextMeshProUGUI sellMoneyText;

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
		if (turretBox.selectedTurret != null) {
			upgradePriceText.text = "UPGRADE\n" + SetPrice ();
			sellMoneyText.text = "SELL\n" + SetSellPrice ();
		}
	}


	public void Upgrade () {
		if (PlayerStats.money >= upgradeSTurr[turretBox.upgradeVersion].cost ) {
				turretBox.UpgradeCurrentTurret (upgradeSTurr);	
			}


		}
			

	public void SellTurret () {
		turretBox.SellCurrentTurret ();
	}

	public int SetPrice (){
		//Set the upgrade price on the correct upgrade path
		if (GetTurretType().Contains("Standard")) {return upgradeSTurr [turretBox.upgradeVersion].cost;}
		if (GetTurretType().Contains("Missile")) return upgradeLTurr[turretBox.upgradeVersion].cost;
		if (GetTurretType().Contains ("Laser")) return upgradeLTurr[turretBox.upgradeVersion].cost;



		return 0;

	}

	public int SetSellPrice (){
		if(turretBox.selectedTurret != null){
			//The index of upgradeversion is -1 because it is setting the sell amount of the current turret not the next one
			if (GetTurretType().Contains("Standard")) {return upgradeSTurr [turretBox.upgradeVersion-1].sellAmount;}
			if (GetTurretType().Contains("Missile")) return upgradeLTurr[turretBox.upgradeVersion-1].sellAmount;
			if (GetTurretType().Contains ("Laser")) return upgradeLTurr[turretBox.upgradeVersion-1].sellAmount;

		}

		return 0;

	}



	public string GetTurretType () {
		if (GetTurretType ().Contains ("Standard")) {
			return turretBox.selectedTurret.prefab.name;
		} else {
			return "";
		}
	}











}
