using UnityEngine;
using System.Collections;

public class TurretBox : MonoBehaviour {

	private Renderer render;
	private Color startColor;
	private Vector3 buildOffSet = new Vector3 (0, 0.37f, 0);
	public TurretSetup selectedTurret;
	private Shop shop;
	public Color hoverColor;
	public GameObject selectedTurretClone; 


	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		startColor = render.material.color;
		shop = GameObject.Find ("Shop").GetComponent<Shop> ();
	}
		

	void OnMouseEnter () {
		if (shop.currentTurret.prefab == null) {
			return;
		}else if(PlayerStats.money < shop.currentTurret.cost){
			render.material.color = Color.red;
		}
		else {
			render.material.color = hoverColor;
		}
		//Instantate upgrade UI game object at current position + offset

	}



	void OnMouseExit () {
		render.material.color = startColor;
	}

	void OnMouseDown () {
		selectedTurret = shop.Buy();
		if (selectedTurret != null && !AlreadyATurret()) {
			SpawnTurret ();
			shop.SpendMoney (selectedTurret);

		} 
		else {
			print ("Already a turret");
		}
		shop.currentTurret = null;

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

	public void UpgradeCurrentTurret (Upgrades[] _upgrades){
		print ("upgrade Button Clicked");
		Instantiate (_upgrades [0].prefab,transform.position+ buildOffSet,transform.rotation);
		Destroy (selectedTurretClone);
	
	}
		
	public void SellCurrentTurret() {
		PlayerStats.money += selectedTurret.sellAmount;
		Destroy (selectedTurretClone);
		selectedTurret = null;


	}

		
}
