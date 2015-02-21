using UnityEngine;
using System.Collections;

public class DoorRotating : MonoBehaviour {
	
	public GameObject doorObject;
	public float returningTime = 5;
	public float speed = 30;
	public bool useKey = false;
	
	private AutoRotate MyRotateScript;
	private bool hasEnter = false;
	
	// Get our rotate script component from the door itself (this is the trigger
	// that 'fires' all the opening/closing door functionality).
	void Start() {
		MyRotateScript = doorObject.GetComponent<AutoRotate>();
	}
	
	// When the player enter in the door's trigger, rotate it
	// and call to the return function
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player")
			hasEnter = true;
	}
		
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player")
			hasEnter = false;
	}
	
	void Update(){
		if(!useKey && hasEnter)
			OpenDoor();
		else
		if(useKey && hasEnter && Input.GetKeyDown(KeyCode.F))
			OpenDoor();
	}
	
	void OpenDoor(){
		MyRotateScript.angles = new Vector3(0,90,0); // axis and angles of the rotation.
		MyRotateScript.speed = new Vector3(0,speed,0); // speed of the rotation en each axis.
		MyRotateScript.RotateInmediate(); // Rotate it.
		StartCoroutine(RotateAgain()); // Rotate back to it's origin position/rotation.
	}
	
	// Closes the door. It will wait "returningTime" seconds, before start rotating.
	IEnumerator RotateAgain () {
		yield return new WaitForSeconds(returningTime);
		MyRotateScript.angles = new Vector3(0,0,0); // return to zero angles in the three axis.
		MyRotateScript.speed = new Vector3(0,speed,0); // speed of the rotation (in Y in this case).
		MyRotateScript.RotateInmediate(); // Mak the rotation.
	}
}
