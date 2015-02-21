//====================================================================================================
//
// Script : AutoScale
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Scale a GameObject in any axis at a given speed.
// 				It uses a delay time if needed (zero if doesn't).
//
//====================================================================================================

using UnityEngine;
using System.Collections;


[AddComponentMenu( "Utilities/AutoScale")]
public class  AutoScale : MonoBehaviour {
	
	public Vector3 targetScale = new Vector3(2.0f, 2.0f, 2.0f);
	public float scaleTime = 2; 
	public float delayTime = 1; // Delay to start increasing/decreasing the intendity.
	public bool isCyclic = true;
	
	private bool Increase = true;
	
	private Vector3 OriginalScale;
	private Transform myTransform; 
	private float internalTime = 0;
	private float rate = 0;
	private float i = 0;
	
	void Start () {
		myTransform = transform;
		OriginalScale = myTransform.localScale;
		rate = 1.0f/scaleTime;
		internalTime = Time.time + delayTime; // setup the first internal delay timer.
	}
	
	void LerpScale(){
		if (i < 1.0f){
			i += Time.deltaTime * rate;
			if(Increase)
				myTransform.localScale = Vector3.Lerp(OriginalScale, targetScale, i);
			else
				myTransform.localScale = Vector3.Lerp(targetScale, OriginalScale, i);
		}
		else
		if(isCyclic){
			Increase = !Increase;
			i = 0;
			internalTime = Time.time + delayTime; // setup the first internal delay timer.
		}
	}
	

	void Update () {
		if(Time.time >= internalTime) // is the time reached our internal delay time?
			LerpScale();
	}
	
	
}