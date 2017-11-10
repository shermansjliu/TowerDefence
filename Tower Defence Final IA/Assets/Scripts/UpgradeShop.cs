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
		upgradePriceText.text = "UPGRADE\n" + SetPrice ();
		sellMoneyText.text = "SELL\n" + SetSellPrice ();
	}


	public void Upgrade () {
		
		if (GetTurretType().Contains("Standard")){
			if (upgradeSTurr [turretBox.upgradeVersion].cost <= PlayerStats.money) {
			}

			turretBox.UpgradeCurrentTurret (upgradeSTurr);
		}
			
	}

	public void SellTurret () {
		turretBox.SellCurrentTurret ();
	}

	public int SetPrice (){
		if(turretBox.selectedTurret != null){
			//Set the upgrade price on the correct upgrade path
			if (GetTurretType().Contains("Standard")) {return upgradeSTurr [turretBox.upgradeVersion].cost;}
			if (GetTurretType().Contains("Missile")) return upgradeLTurr[turretBox.upgradeVersion].cost;
			if (GetTurretType().Contains ("Laser")) return upgradeLTurr[turretBox.upgradeVersion].cost;

		}

		return 0;

	}

	public int SetSellPrice (){
		if(turretBox.selectedTurret != null){
			if (GetTurretType().Contains("Standard")) {return upgradeSTurr [turretBox.upgradeVersion].sellAmount;}
			if (GetTurretType().Contains("Missile")) return upgradeLTurr[turretBox.upgradeVersion].sellAmount;
			if (GetTurretType().Contains ("Laser")) return upgradeLTurr[turretBox.upgradeVersion].sellAmount;

		}

		return 0;

	}



	public string GetTurretType () {
		return turretBox.selectedTurret.prefab.name;

	}











}
