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

[AddComponentMenu( "Utilities/AutoMove")]
public class  AutoMove : MonoBehaviour {
	
	public Transform destTransform; //  The destination object where we wanna go.
	public Vector3 destPoint = Vector3.zero; // Destination point if needed (there isnt an object to go to)
	public float moveTime = 2;  // The time that gets to reach destination.
	public bool isCyclic = false;
	public bool isLocal = false;
	public bool isActive = false;
	
	// private values to make all work perfectly fine.
	private bool Increase = true; // are we going or returning?
	private Vector3 OriginalPosition; // Thats my inicial original position (so i can come back).
	private Transform myTransform; 	  // My actual tranform (no need to get the Unity's tranform  anymore in the script).
	private float rate = 0;	// rate used to do my interpolation (the lerp function)
	private float i = 0;    // used to do my interpolation too (the lerp function)
	
	private float moveTimePrev = 2; 
	
	
	void Inicialize(){
		if(isLocal)
			OriginalPosition = myTransform.localPosition;
		else
			OriginalPosition = myTransform.position;
		
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
		
		// If the position where we wanna go is the same that the object starting position
		// then there isn't any movement to do.
		//if(!destTransform && OriginalPosition == destPoint){ return; }
			
		// Update the movement of our object.
		LerpPosition();
	}
	
	public void MoveInmediate(){
		if (i < 1.0f)
			return;
		Increase = true;
		i = 0;
		//LerpPosition();
	}
	
	public void ReturnInmediate(){
		if (i < 1.0f)
			return;
		Increase = false;
		i = 0;
		//LerpPosition();
	}
	
	// We fo a interpolation betwen our position and dest position, so the gameobject
	// will move at certain speed to get there in the time specified by the user.
	void LerpPosition(){
		if (i < 1.0f){ 
			// i goes from zero to 1 at certain rate (given by the movetime).
			i += Time.deltaTime * rate;
			// Do our interpolations from one point in space to another (going & returning).
			if(Increase){
				if(destTransform){
					if(isLocal)
						myTransform.localPosition = Vector3.Lerp(OriginalPosition, destTransform.localPosition, i);
					else
						myTransform.position = Vector3.Lerp(OriginalPosition, destTransform.position, i);
				}
				else{
					if(isLocal)
						myTransform.localPosition = Vector3.Lerp(OriginalPosition, destPoint, i);
					else
						myTransform.position = Vector3.Lerp(OriginalPosition, destPoint, i);
				}
			}
			else{
				if(destTransform){
					if(isLocal)
						myTransform.localPosition = Vector3.Lerp(destTransform.localPosition, OriginalPosition, i);
					else
						myTransform.position = Vector3.Lerp(destTransform.position, OriginalPosition, i);
				}
				else{
					if(isLocal)
						myTransform.localPosition = Vector3.Lerp(destPoint, OriginalPosition, i);
					else
						myTransform.position = Vector3.Lerp(destPoint, OriginalPosition, i);
				}
			}
		}
		else
		if(isCyclic){ // if is a cyclic movement, make it to start again returning/going from one point to another.
			Increase = !Increase;
			i = 0;
		}
	}
	
	
}