using UnityEngine;
using System.Collections;
using TMPro;

public class TurretBox : MonoBehaviour {

	private Renderer render;
	private Color startColor;
	private Vector3 buildOffSet = new Vector3 (0, 0.37f, 0);

	private Shop shop;

	//public int upgradePrice;
	public int upgradeVersion;
	public TurretSetup selectedTurret;
	public Color hoverColor;
	public GameObject selectedTurretClone; 
	public GameObject upgradeShopUI;
	public GameObject upgradeButton;




	// Use this for initialization
	void Start () {
		
		upgradeVersion = 1;
		render = GetComponent<Renderer> ();
		startColor = render.material.color;
		shop = GameObject.Find ("Shop").GetComponent<Shop> ();

	}

	void Update () {
		//If esc key is hit delte upgrade ui
		if (Input.GetKeyDown (KeyCode.Escape)) {
			upgradeShopUI.SetActive (false);
		}

			
	}


		

	void OnMouseEnter () {
		if (shop.currentTurret.prefab == null) {
			render.material.color = startColor;
		}else if(SaveDataManager.money < shop.currentTurret.cost){
			render.material.color = Color.red;
		}
		else {
			render.material.color = hoverColor;
		}

	}



	void OnMouseExit () {
		render.material.color = startColor;
	}

	void OnMouseDown () {
		
		
		if (shop.currentTurret != null && !AlreadyATurret()) {
			selectedTurret = shop.Buy();
			SpawnTurret ();
			//Gets the ID of the turret instance that has just been spawned
			if(AlreadyATurret())
			UIManager._UImInstance.GetID (this.GetInstanceID());
			shop.SpendMoney (selectedTurret);
			//Deselect Turret;
			shop.currentTurret = null;

		} 
		else if(selectedTurret.prefab!=null){
			//When there is a turret already on the node and it is clicked on, spawn a the upgrade shop UI
			if (upgradeShopUI.activeInHierarchy == false) {
				upgradeShopUI.SetActive (true);
			}
			//If the ID of another turret is not different don't do anyhing
		

		
		}
	

	}

	void SpawnTurret () {
		selectedTurretClone = (GameObject)Instantiate (selectedTurret.prefab, transform.position + buildOffSet, transform.rotation);

	}

	bool AlreadyATurret () {
		if (selectedTurretClone == null) {
			return false;
		} 
	
		return true;
		
	}

	public void UpgradeCurrentTurret (TurretSetup[] upgradedTurret){
		//Check if there are any more possible upgrades
		if (upgradeVersion < upgradedTurret.Length) {
			//Destroy instance of previous turret
			Destroy (selectedTurretClone);
			//Make the current turret of this Node set to upgraded turret
			selectedTurret = upgradedTurret [upgradeVersion];
			//Spawn the new upgraded Turret;
			SpawnTurret ();
			upgradeVersion++;
		} if(upgradeVersion == upgradedTurret.Length){
			upgradeButton.SetActive (false);
		}

	
	
	}
		
	public void SellCurrentTurret() {
		SaveDataManager.money += selectedTurret.sellAmount;
		Destroy (selectedTurretClone);
		selectedTurret = null;
		upgradeVersion = 1;
		upgradeShopUI.SetActive (false);


	}

		
}
