using UnityEngine;
using System.Collections;

public class DoorMoving : MonoBehaviour {
	
	public GameObject doorObject;
	public float movingTime = 30;
	public float delayTime = 5;
	public Vector3 destPoint = Vector3.zero;
	private Vector3 OriginalPoint = Vector3.zero;
	
	private AutoMove MyMoveScript;
	
	// Get our rotate script component from the door itself (this is the trigger
	// that 'fires' all the opening/closing door functionality).
	void Start() {
		MyMoveScript = doorObject.GetComponent<AutoMove>();
		OriginalPoint = this.transform.position;
	}
	
	// When the player enter in the door's trigger, rotate it
	// and call to the return function
	void OnTriggerEnter(Collider other) {
		MyMoveScript.isActive = true;
		if(other.tag == "Player"){
			MyMoveScript.destPoint = OriginalPoint+destPoint; // axis and angles of the rotation.
			MyMoveScript.moveTime = movingTime; // speed of the rotation en each axis.
			MyMoveScript.MoveInmediate(); // Rotate it.
			StartCoroutine(MoveAgain()); // Rotate back to it's origin position/rotation.
		}
	}
	
	// Closes the door. It will wait "returningTime" seconds, before start rotating.
	IEnumerator MoveAgain () {
		yield return new WaitForSeconds(delayTime);
		//MyMoveScript.destPoint = OriginalPoint; // return to zero angles in the three axis.
		//MyMoveScript.moveTime = movingTime; // speed of the rotation (in Y in this case).
		MyMoveScript.ReturnInmediate(); // Mak the rotation.
	}
}
