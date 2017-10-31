using UnityEngine;
using System.Collections;

public class TurretBox : MonoBehaviour {

	private Renderer render;
	private bool mouseHover = false;
	private Color startColor;
	private Vector3 buildOffSet = new Vector3 (0, 0.37f, 0);
	public TurretSetup selectedTurret;

	private Shop shop;
	public Color hoverColor;

	private GameObject tempTurret;


	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		startColor = render.material.color;
		shop = GameObject.Find ("Shop").GetComponent<Shop> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0))	 {
			AlreadyATurret ();
		}
			
	}
	void OnMouseEnter () {
		if (selectedTurret == null) {
			render.material.color = Color.red;
		} else {
			render.material.color = hoverColor;
		}

	}

	void OnMouseExit () {
		render.material.color = startColor;
	}

	void OnMouseDown () {
		selectedTurret = shop.Buy();
		if (selectedTurret != null && !AlreadyATurret()) {
			SpawnTurret ();
			shop.BuyTurret (selectedTurret);
		} else {
			print ("Already a turret");
		}


	}

	void SpawnTurret () {
		Instantiate (selectedTurret.prefab, transform.position + buildOffSet, transform.rotation);
		tempTurret = selectedTurret.prefab;

	}

	bool AlreadyATurret () {
		if (tempTurret == null) {
			return false;
		} 
			else {
			Debug.Log ("Already a turret");
		}

		return true;;
		
	}
		
}
