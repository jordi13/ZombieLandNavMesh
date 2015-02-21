//====================================================================================================
//
// Script : Elevator
// Programador : Julian Oliden. "Jocyf"
//
// Date: 09/04/2013
// Version : 1.5
//
// Description: Start the movement of the elevator, based on trigger events.
// 				The AutoMove has to have all to zero and all option disabled.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	
	
	public Vector3 destPoint = Vector3.zero;
	public float movingTime = 30;
	public float delayTime = 5;
	public bool stay = false; // is the elevator stays at dest position or it will return after a delayTime (returningTime).
	
	private GameObject doorObject;
	private Vector3 OriginalPoint = Vector3.zero;
	private AutoMove MyMoveScript;
	
	// Get our rotate script component from the door itself (this is the trigger
	// that 'fires' all the opening/closing door functionality).
	void Start() {
		doorObject = this.transform.parent.gameObject;
		MyMoveScript = doorObject.GetComponent<AutoMove>();
		OriginalPoint = doorObject.transform.position;
		MyMoveScript.moveTime = movingTime;
	}
	
	// When the player enter in the door's trigger, rotate it
	// and call to the return function
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			MyMoveScript.isActive = true;
			if(stay){
				if(doorObject.transform.position == OriginalPoint){
					MyMoveScript.destPoint = OriginalPoint+destPoint; // axis and angles of the rotation.
					MyMoveScript.moveTime = movingTime; // speed of the rotation en each axis.
					MyMoveScript.MoveInmediate(); // Rotate it.
				}
				else
				if(doorObject.transform.position == OriginalPoint+destPoint)
					MyMoveScript.ReturnInmediate();
			}
			else{
				if(doorObject.transform.position == OriginalPoint){
					MyMoveScript.destPoint = OriginalPoint+destPoint; // axis and angles of the rotation.
					MyMoveScript.moveTime = movingTime; // speed of the rotation en each axis.
					MyMoveScript.MoveInmediate(); // Rotate it.
					StartCoroutine(MoveAgain()); // Rotate back to it's origin position/rotation.
				}
				else
				if(doorObject.transform.position == OriginalPoint+destPoint)	
					MyMoveScript.ReturnInmediate();
			}
		}
	}
	
	// Closes the door. It will wait "returningTime" seconds, before start rotating.
	IEnumerator MoveAgain () {
		yield return new WaitForSeconds(delayTime);
		MyMoveScript.ReturnInmediate();
	}
}
