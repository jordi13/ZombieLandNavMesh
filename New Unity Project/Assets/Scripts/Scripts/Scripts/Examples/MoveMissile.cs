//=========================================================================================================
//
// Script : AutoMove
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.4
//
// Description: Moves a gameobject to a destination at a given time. The destiny can be a point in 
//				space or a target gameobject. If the target Object exist, the destination point is ignored.
//
//=========================================================================================================

using UnityEngine;
using System.Collections;

public class  MoveMissile : MonoBehaviour {
	
	public float speed = 2;  // The time that gets to reach destination.

	private Transform myTransform; 	  // My actual tranform (no need to get the Unity's tranform  anymore in the script).
	private Transform target;
	
	
	void Start () {
		// Get some values and save them just at the beg	ining.
		myTransform = transform;
		//target = GameObject.Find("First Person Controller").transform;
		target = Camera.main.transform;
	}
	
	void Update () {

		float dist = Vector3.Distance(myTransform.position, target.position);
		if(dist < 0.3f){
			Debug.Log("Missile hit!!!!");
		}

		myTransform.Translate(Vector3.forward*speed*Time.deltaTime, Space.Self);
	}
	
}