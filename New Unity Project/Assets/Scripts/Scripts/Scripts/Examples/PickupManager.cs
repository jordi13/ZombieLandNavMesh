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


public class  PickupManager : MonoBehaviour {
	
	public enum pickupType { Health, Ammo, Mana };
	
	public pickupType type = pickupType.Health;
	
	//public Transform destTransform; //  The destination object where we wanna go.
	public Vector3 destPoint = new Vector3(0, 1, 0); // Destination point if needed (there isnt an object to go to)
	public float moveTime = 2;  // The time that gets to reach destination.
	public float spinSpeed = 180;  // The time that gets to reach destination.
	private bool isCyclic = true;
	private bool isActive = true;
	
	// private values to make all work perfectly fine.
	private bool Increase = true; // are we going or returning?
	private Vector3 OriginalPosition; // Thats my inicial original position (so i can come back).
	private Transform myTransform; 	  // My actual tranform (no need to get the Unity's tranform  anymore in the script).
	private float rate = 0;	// rate used to do my interpolation (the lerp function)
	private float i = 0;    // used to do my interpolation too (the lerp function)
	
	private float moveTimePrev = 2; 
	
	
	void Inicialize(){
		OriginalPosition = myTransform.position;
		destPoint = OriginalPosition + destPoint;
		rate = 1.0f/moveTime; // needed to do the lerp in the right way.
		i = 0;
	}
	
	
	void Start () {
		// Get some values and save them just at the begining.
		myTransform = transform;
		Inicialize();
		moveTimePrev = moveTime; // used to detect user changes in inspector.
	}
	
	void Update () {
		if(!isActive)
			return;
		
		// Make sure that time is never zero.
		if(moveTime <= 0)
			moveTime = 0.01f;
		// Detect any change that the user can do in inspector.
		if(moveTimePrev != moveTime){
			rate = 1.0f/moveTime;
			moveTimePrev = moveTime;
		}
		
		myTransform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);
		
		// If the position where we wanna go is the same that the object starting position
		// then there isn't any movement to do.
		//if(!destTransform && OriginalPosition == destPoint){ return; }
			
		// Update the movement of our object.
		LerpPosition();
	}
	
	
	// We fo a interpolation betwen our position and dest position, so the gameobject
	// will move at certain speed to get there in the time specified by the user.
	void LerpPosition(){
		if (i < 1.0f){ 
			// i goes from zero to 1 at certain rate (given by the movetime).
			i += Time.deltaTime * rate;
			// Do our interpolations from one point in space to another (going & returning).
			if(Increase)
				myTransform.position = Vector3.Lerp(OriginalPosition, destPoint, i);
			else
				myTransform.position = Vector3.Lerp(destPoint, OriginalPosition, i);
		}
		else
		if(isCyclic){ // if is a cyclic movement, make it to start again returning/going from one point to another.
			Increase = !Increase;
			i = 0;
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			switch (type){
				case pickupType.Health:
					// TO-DO : Add health to the main player.
					// MyPlayer.Health += 10; // Example.
					Debug.Log("DetectPickup : Health picked!.");
					break;
				case pickupType.Ammo:
					// TO-DO : Add ammo to the main player.
					Debug.Log("DetectPickup : Ammo picked!.");
					break;
				case pickupType.Mana:
					// TO-DO : Add mana to the main player.
					Debug.Log("DetectPickup : Mana picked!.");
					break;
				default :
					// TO-DO : ¿do nothing? ¿Display a warning msg?.
					Debug.Log("DetectPickup : This Pickup doesnt have a type.");
					break;
			}
		}
	}
	
}