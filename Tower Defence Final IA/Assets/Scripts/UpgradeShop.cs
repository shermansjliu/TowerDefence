using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class UpgradeShop : MonoBehaviour {
	private float upgradeVersion;
	[Header("Standard Upgrades")]
	public Upgrades[] upgradeSTurr;
	[Header("Missile Upgrades")]
	public Upgrades[] upgradeMTurr;
	[Header("Laser Upgrades")]
	public Upgrades[] upgradeLTurr;

	public GameObject turretOnNode;
	bool isUISelected;
	TurretBox turretBox;

	Shop shop;
	// Use this for initialization


	void Start () {
		shop = GameObject.Find ("Shop").GetComponent<Shop> ();
		turretBox = GetComponentInParent<TurretBox> ();
		Upgrades[] upgradeSturr = new Upgrades[1];
		Upgrades[] upgradeMTurr = new Upgrades[1];
		Upgrades[] upgradeLTurr = new Upgrades[1];
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void findTurretType () {
		if (turretBox.selectedTurret.prefab.name.Contains("Standard")){
			turretBox.UpgradeCurrentTurret (upgradeSTurr);
		}
			
	}

	public void SellTurret () {
		turretBox.SellCurrentTurret ();
	}









}
