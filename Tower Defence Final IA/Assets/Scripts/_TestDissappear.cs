using UnityEngine;
using System.Collections;

public class _TestDissappear : MonoBehaviour {
	public Renderer ball;
	public bool isActive;
	public GameObject menu;

	Renderer render;
	// Use this for initialization
	void Start () {
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			print ("HI");
			isActive = !isActive;
			menu.SetActive (false);
			ball.enabled = isActive;
		}
	}


}
