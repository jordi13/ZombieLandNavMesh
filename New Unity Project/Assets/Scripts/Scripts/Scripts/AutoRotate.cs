//====================================================================================================
// Copyright Julian Oliden "Jocyf" 2013 - 29-01-2013
// AutoSpin v1.1
// Rotate a GameObject in any axis, using local o global coordinates.
//
// How to use it:
// Drag this script to any gameobect and write the desired speed in each axis (zero for no rotation).
//
///==================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoRotate")]
public class AutoRotate : MonoBehaviour {
	
	public Vector3 angles = new Vector3 (0, 0, 0); // Speed of the rotation in each axis.
	public Vector3 speed = new Vector3 (0, 0, 0); // Speed of the rotation in each axis.
	public bool local = false;		// Is the rotation in local space (or in global)
	public bool randomize = false;	// Make the velocity randomized (min is zero , max is the velocity of speed var.)
	public bool cyclic = false;
	
	private Vector3 anglesAux = Vector3.zero;
	private Vector3 localAnglesAux = Vector3.zero;
	private bool isComplete = false;
	private bool isGoingUp = true;
	private Transform MyTransform;
	private Vector3 OrigEulerAngles = Vector3.zero;
	private Vector3 OrigLocalEulerAngles = Vector3.zero;
	
	
	void ResetUnusedAngles(){
		if(local){
			if(speed.x == 0) 
				angles.x = OrigLocalEulerAngles.x;
			if(speed.y == 0) 
				angles.y = OrigLocalEulerAngles.y;
			if(speed.z == 0) 
				angles.z = OrigLocalEulerAngles.z;
		}
		else{
			if(speed.x == 0) 
				angles.x = OrigEulerAngles.x;
			if(speed.y == 0) 
				angles.y = OrigEulerAngles.y;
			if(speed.z == 0) 
				angles.z = OrigEulerAngles.z;
		}
	}
	
	void Start(){
		MyTransform = this.transform;
		OrigEulerAngles = MyTransform.eulerAngles;
		OrigLocalEulerAngles = MyTransform.localEulerAngles;
		
		ResetUnusedAngles();
		
		if(randomize)
			speed = new Vector3(Random.Range(0,speed.x), Random.Range(0,speed.y), Random.Range(0,speed.z));
	}
	
	
	void Update(){
		if(isComplete && cyclic){
			isGoingUp = !isGoingUp;
			isComplete = false;
		}
			
		if(isGoingUp)
			RotatingUp();
		else
			RotatingDown();
	}
	
	public void RotateInmediate(){
		isGoingUp = true;
		isComplete = false;
		ResetUnusedAngles();
		RotatingUp();
	}
		
	void RotatingUp(){
		if(speed.x > 0){
			if(local)
				localAnglesAux.x = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, angles.x, speed.x * Time.deltaTime);
			else
				anglesAux.x = Mathf.MoveTowardsAngle(transform.eulerAngles.x, angles.x, speed.x * Time.deltaTime);
		}
		if(speed.y > 0){
			if(local)
				localAnglesAux.y = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, angles.y, speed.y * Time.deltaTime);
			else
				anglesAux.y = Mathf.MoveTowardsAngle(transform.eulerAngles.y, angles.y, speed.y * Time.deltaTime);
		}
		if(speed.z > 0){
			if(local)
				localAnglesAux.z = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, angles.z, speed.z * Time.deltaTime);
			else
				anglesAux.z = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angles.z, speed.z * Time.deltaTime);
		}
		
		if(local)
			transform.localEulerAngles = localAnglesAux;
		else
			transform.eulerAngles = anglesAux;
		
		
		if(local && Vector3.Distance(angles, transform.localEulerAngles) < 0.1f)
			isComplete = true;
		else
		if(!local && Vector3.Distance(angles, transform.eulerAngles) < 0.1f)
			isComplete = true;
	}
	
	void RotatingDown(){
		if(speed.x > 0){
			if(local)
				localAnglesAux.x = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, OrigLocalEulerAngles.x, speed.x * Time.deltaTime);
			else
				anglesAux.x = Mathf.MoveTowardsAngle(transform.eulerAngles.x, OrigEulerAngles.x, speed.x * Time.deltaTime);
		}
		if(speed.y > 0){
			if(local)
				localAnglesAux.y = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, OrigLocalEulerAngles.y, speed.y * Time.deltaTime);
			else
				anglesAux.y = Mathf.MoveTowardsAngle(transform.eulerAngles.y, OrigEulerAngles.y, speed.y * Time.deltaTime);
		}
		if(speed.z > 0){
			if(local)
				localAnglesAux.z = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, OrigLocalEulerAngles.z, speed.z * Time.deltaTime);
			else
				anglesAux.z = Mathf.MoveTowardsAngle(transform.eulerAngles.z, OrigEulerAngles.z, speed.z * Time.deltaTime);
		}
		
		if(local)
			transform.localEulerAngles = localAnglesAux;
		else
			transform.eulerAngles = anglesAux;
		
		
		if(local && Vector3.Distance(OrigLocalEulerAngles, transform.localEulerAngles) < 0.1f)
			isComplete = true;
		else
		if(!local && Vector3.Distance(OrigEulerAngles, transform.eulerAngles) < 0.1f)
			isComplete = true;
	}
	
}