using UnityEngine;
using System.Collections;

public class CamerMovement : MonoBehaviour {

	public float moveSpeed;
	public float scrollSpeed;
	public float zoomOutAmount;
	public float zoomInAmount;
	public Vector2 edgeLimit;

	Vector3 startPos;
	Vector3 desiredPos;
	Vector3 smoothedPos;






	void Start () {
		desiredPos = transform.position;
		startPos = transform.position;


	}
	// Update is called once per frame after all Physics calculations have been run
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W)) {MoveUp ();}
		if (Input.GetKey (KeyCode.A)) {MoveLeft ();}
		if (Input.GetKey (KeyCode.S)) {MoveDown ();}
		if (Input.GetKey(KeyCode.D)) {MoveRight ();}



		Zoom ();
		desiredPos.y = Mathf.Clamp (desiredPos.y, 20f, 77.6f);

		//Smooth out the transition from initial position to the  desired position 
		smoothedPos = Vector3.Lerp (transform.position, desiredPos, moveSpeed * Time.deltaTime);

		//Move camera position
		transform.position = smoothedPos;

	

	}

	void MoveLeft () {
		if(desiredPos.x > startPos.x-30)
		desiredPos.x -= moveSpeed * Time.deltaTime;


	}

	void MoveRight () {
		if (desiredPos.x < startPos.x + 30) 
			desiredPos.x += moveSpeed * Time.deltaTime;
		
	}

	void MoveUp () {
		if(desiredPos.z < startPos.z + 90)
		desiredPos.z += moveSpeed * Time.deltaTime;
	}

	void MoveDown () {
		if(desiredPos.z > startPos.z -75)
		desiredPos.z -= moveSpeed * Time.deltaTime;
	}

	void Zoom () {
	//Move along scrollAxis
		//Store Unity's prebuilt axis in a temp variable
		float scrollAxis= Input.GetAxis("Mouse ScrollWheel");
		desiredPos.y -= scrollAxis * 100.0f * scrollSpeed *Time.deltaTime;

	}


}
