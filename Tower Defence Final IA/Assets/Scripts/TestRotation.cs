using UnityEngine;
using System.Collections;

public class TestRotation : MonoBehaviour {
	public GameObject partThatRotates;
	public Transform target;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TestRotate ();
	
	}
	void TestRotate (){
		Vector3 directionToEnemy = (target.position - transform.position);
		Quaternion targetRotation = Quaternion.LookRotation (directionToEnemy);
		targetRotation.x = 0;
		targetRotation.z = 0;
		partThatRotates.transform.rotation = Quaternion.Slerp (partThatRotates.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

	}
}
