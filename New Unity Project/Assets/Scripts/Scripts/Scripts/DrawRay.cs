//====================================================================================================
//
// Script : DrawRay
// Programador : Julian Oliden. "Jocyf"
//
// Date: 06/04/2013
// Version : 1.1
//
// Description: Draws a ray from the camera to a target or forward a given lenght.
// 				Drag this script to any gameobect (the MainCamera is the most used option).
//
//====================================================================================================
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

[AddComponentMenu( "Utilities/DrawRay")]
public class DrawRay : MonoBehaviour {
	
	public Color rayColor = Color.green;	// Color of the ray.
	public Transform target;				// Gameobject that will be the target of the ray (optional).
	public bool LookatTarget = false;		// Will de camera look at the target?
	public int lenght = 10;					// Lenght of the ray if there isn't a target.
	
	private Vector3 forward = Vector3.zero;  // Private vector used to setup de ray direction.


	void Update() {
		// If is there a target
		if(target){
			// the current gameobject is gonna look always to the target (follow it), 
			if(LookatTarget)
				transform.LookAt(target);
			// we need de vector that goes from the target to our gameobject.
			forward = target.position - transform.position;
		}
		// There is no target, just look forward this gameobject.
		else
			forward = transform.TransformDirection(Vector3.forward) * lenght;
		
		// Draw the ray
		Debug.DrawRay (transform.position, forward, rayColor);
	}
	
}