using UnityEngine;
using System.Collections;

//System.Seralizable is used so that the class can be viewed in the inspector
[System.Serializable]
public class TurretSetup{
	//The foundation of a turret in a shop contains the a turret type i.e a gameObject, the initial cost, and the intial sell amount
	public GameObject prefab;
	public int cost;
	public int sellAmount;

}
