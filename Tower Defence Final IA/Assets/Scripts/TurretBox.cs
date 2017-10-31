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


	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		startColor = render.material.color;
		shop = GameObject.Find ("Shop").GetComponent<Shop> ();
	}

	void OnMouseEnter () {
		render.material.color = hoverColor;
	}

	void OnMouseExit () {
		render.material.color = startColor;
	}

	void OnMouseDown () {
		Debug.Log (shop);
		selectedTurret = shop.Buy();
		if (selectedTurret != null) {
			SpawnTurret ();
		}
		//If turret already on turret box

	}

	void SpawnTurret () {
		Debug.Log (selectedTurret);
		Debug.Log(transform.rotation);
		Debug.Log (selectedTurret.prefab);
		Instantiate (selectedTurret.prefab, transform.position + buildOffSet, transform.rotation);
	}
		
}
