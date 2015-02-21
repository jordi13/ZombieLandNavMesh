using UnityEngine;
using System.Collections;

public class DoorMoving2 : MonoBehaviour {
	
	public GameObject doorObject;
	public float movingTime = 2;
	public float delayTime = 5;
	public Transform destTransform;
	private Vector3 destPoint;
	private Vector3 OriginalPoint = Vector3.zero;
	
	private bool Increase = false; // are we going or returning?
	private float internalDelayTime = 1;
	private float rate = 0;	// rate used to do my interpolation (the lerp function)
	private float i = 1;    // used to do my interpolation too (the lerp function)
	
	// Get our rotate script component from the door itself (this is the trigger
	// that 'fires' all the opening/closing door functionality).
	void Start() {
		OriginalPoint = this.transform.position;
		destPoint = destTransform.position;
		rate = 1.0f/movingTime; // needed to do the lerp in the right way.
	}
	
	// When the player enter in the door's trigger, rotate it
	// and call to the return function
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			Increase = true;
			i = 0;
			internalDelayTime = Time.time + delayTime;
		}
	}
	
	void Update(){
		if (i < 1.0f){ 
			// i goes from zero to 1 at certain rate (given by the movetime).
			i += Time.deltaTime * rate;
			// Do our interpolations from one point in space to another (going & returning).
			if(Increase)				
				doorObject.transform.position = Vector3.Lerp(OriginalPoint, destPoint, i);
			else
				doorObject.transform.position = Vector3.Lerp(destPoint, OriginalPoint, i);
		}
		
		if(Time.time >= internalDelayTime && Increase){
			Increase = false;
			i = 0;
		}
	}
}
