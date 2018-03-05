using UnityEngine;
using System.Collections;

public class MenuTurretRotation : MonoBehaviour {
	public int speed;	
	// Update is called once per frame
	void Update () {
		Vector3 rotationOnY = new Vector3 (0, transform.position.y, 0);
		transform.Rotate (rotationOnY * speed * Time.deltaTime, Space.World);

	}
}
