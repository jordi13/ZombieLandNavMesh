using UnityEngine;
using System.Collections;

public class Elevator2 : MonoBehaviour {
	
	private GameObject doorObject;
	public Transform destPoint;
	public float movingTime = 30;
	public float delayTime = 5;
	public bool stay = false; // is the elevator stays at dest position or it will return after a delayTime (returningTime).
	
	private Vector3 OriginalPoint = Vector3.zero;
	private AutoMove MyMoveScript;
	
	// Get our rotate script component from the door itself (this is the trigger
	// that 'fires' all the opening/closing door functionality).
	void Start() {
		doorObject = this.transform.parent.gameObject;
		MyMoveScript = doorObject.GetComponent<AutoMove>();
		OriginalPoint = this.transform.localPosition;
		MyMoveScript.moveTime = movingTime;
	}
	
	// When the player enter in the door's trigger, rotate it
	// and call to the return function
	void OnTriggerEnter(Collider other) {
		MyMoveScript.isActive = true;
		if(other.tag == "Player"){
			if(stay){
				if(doorObject.transform.localPosition == OriginalPoint){
					MyMoveScript.destTransform = destPoint; // axis and angles of the rotation.
					MyMoveScript.moveTime = movingTime; // speed of the rotation en each axis.
					MyMoveScript.MoveInmediate(); // Rotate it.
				}
				else
				if(doorObject.transform.localPosition == destPoint.localPosition)
					MyMoveScript.ReturnInmediate();
			}
			else{
				if(doorObject.transform.localPosition == OriginalPoint){
					MyMoveScript.destTransform = destPoint; // axis and angles of the rotation.
					MyMoveScript.moveTime = movingTime; // speed of the rotation en each axis.
					MyMoveScript.MoveInmediate(); // Rotate it.
					StartCoroutine(MoveAgain()); // Rotate back to it's origin position/rotation.
				}
				else
				if(doorObject.transform.localPosition == destPoint.localPosition)	
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
