//====================================================================================================
//
// Script : AutoSpin
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Rotate a GameObject in any axis, using local o global coordinates.
// 				It uses a delay time if needed (zero if doesn't).
//
//====================================================================================================
using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoSpin")]
public class AutoSpin : MonoBehaviour {
	
	public Vector3 speed = new Vector3 (2, 2, 2); // Speed of the rotation in each axis.
	public bool local = false;		// Is the rotation in local space (or in global)
	public bool randomize = false;	// Make the velocity randomized (min is zero , max is the velocity of speed var.)
	
	private Transform MyTransform;
	
	void Start(){
		MyTransform = this.transform;
		if(randomize)
			speed = new Vector3(Random.Range(0,speed.x), Random.Range(0,speed.y), Random.Range(0,speed.z));
	}
	
	void Update() {
		if(speed.x > 0){
			if(local)
				MyTransform.Rotate(Vector3.right, speed.x * Time.deltaTime, Space.Self);
			else
				MyTransform.Rotate(Vector3.right, speed.x * Time.deltaTime, Space.World);
		}
		if(speed.y > 0){
			if(local)
				MyTransform.Rotate(Vector3.up, speed.y * Time.deltaTime, Space.Self);
			else
				MyTransform.Rotate(Vector3.up, speed.y * Time.deltaTime, Space.World);
		}
		if(speed.z > 0){
			if(local)
				MyTransform.Rotate(Vector3.forward, speed.z * Time.deltaTime, Space.Self);
			else
				MyTransform.Rotate(Vector3.forward, speed.z * Time.deltaTime, Space.World);
		}
	}
	
}