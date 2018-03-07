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

	private bool isUISelected;
	private TurretBox turretBox;


	// Use this for initialization


	void Start () {
		turretBox = GetComponentInParent<TurretBox> ();
	}


	void Update () {
		if (turretBox.selectedTurretClone != null) {
			upgradePriceText.text = "UPGRADE\n" + SetPrice ();
			sellMoneyText.text = "SELL\n" + SetSellPrice ();
		}

	}


	public void Upgrade () {
		if (GetTurretType ().Contains ("Standard")) {
			if (SaveDataManager.money >= upgradeSTurr [turretBox.upgradeVersion].cost) {
				SaveDataManager.money -= upgradeSTurr [turretBox.upgradeVersion].cost;
				turretBox.UpgradeCurrentTurret (upgradeSTurr);	

			}

		}else if (GetTurretType ().Contains ("Missile")) {
			if (SaveDataManager.money >= upgradeMTurr [turretBox.upgradeVersion].cost) {
				SaveDataManager.money -= upgradeMTurr [turretBox.upgradeVersion].cost;
				turretBox.UpgradeCurrentTurret (upgradeMTurr);	
			}
		}else if (GetTurretType ().Contains ("Laser")) {
			if (SaveDataManager.money >= upgradeLTurr [turretBox.upgradeVersion].cost) {
				SaveDataManager.money -= upgradeLTurr [turretBox.upgradeVersion].cost;
				turretBox.UpgradeCurrentTurret (upgradeLTurr);	
			}
		}
	}
			

	public void SellTurret () {
		turretBox.SellCurrentTurret ();
	}

	public int SetPrice (){
		//Set the upgrade price on the correct upgrade path

		if (GetTurretType().Contains("Standard")) {
			if(turretBox.upgradeVersion < upgradeSTurr.Length)
				return upgradeSTurr [turretBox.upgradeVersion].cost;}
		if (GetTurretType ().Contains ("Missile")) {
			return upgradeMTurr [turretBox.upgradeVersion].cost;
		}
		if (GetTurretType ().Contains ("Laser")) {
			return upgradeLTurr [turretBox.upgradeVersion].cost;	
		}



		return 0;

	}

	public int SetSellPrice (){
			//The index of upgradeversion is -1 because it is setting the sell amount of the current turret not the next one
		if (GetTurretType().Contains("Standard")) {return upgradeSTurr [turretBox.upgradeVersion-1].sellAmount;}
		if (GetTurretType().Contains("Missile")) return upgradeMTurr[turretBox.upgradeVersion-1].sellAmount;
		if (GetTurretType().Contains ("Laser")) return upgradeLTurr[turretBox.upgradeVersion-1].sellAmount;
	


		return 0;

	}




	public string GetTurretType () {
		return turretBox.selectedTurretClone.name;
		
	}











}
