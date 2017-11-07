using UnityEngine;
using System.Collections;

public class UpgradeShop : MonoBehaviour {
	private float upgradeVersion;
	[Header("Standard Upgrades")]
	public Upgrades[] upgradeSTurr;
	[Header("Missile Upgrades")]
	public Upgrades[] upgradeMTurr;
	[Header("Laser Upgrades")]
	public Upgrades[] upgradeLTurr;
	// Use this for initialization
	void Start () {
		Upgrades[] upgradeSturr = new Upgrades[1];
		Upgrades[] upgradeMTurr = new Upgrades[1];
		Upgrades[] upgradeLTurr = new Upgrades[1];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
