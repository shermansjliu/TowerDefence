﻿using UnityEngine;
using System.Collections;

public class StandardEnemy : MonoBehaviour {

	private int wayPointIndex = 0;
	private Transform currWayPoint;

	public int health = 100;
	public int moveSpeed = 10;



	void Start(){
		currWayPoint = StoreWayPoints.wayPoints [0];
		print (currWayPoint.position.y);
		

	}
	void Update () {
		Vector3 direcition = currWayPoint.position - transform.position;
		transform.position = Vector3.MoveTowards (transform.position, currWayPoint.position, moveSpeed * Time.deltaTime);


		if(Vector3.Distance(transform.position, currWayPoint.position)<=0.2){
			getNextWayPoint();
		}
		
	}
			

	private void getNextWayPoint(){
		wayPointIndex++;

	}
}
