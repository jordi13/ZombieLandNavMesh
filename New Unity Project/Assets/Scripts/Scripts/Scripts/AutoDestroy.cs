//====================================================================================================
//
// Script : AutoDestroy
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Destroy a gameobject at the time specified.
// 				The time have to be a value greater than zero.
//				To destroy inmediatly call DestroyInmediate() function.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoDestroy")]
public class AutoDestroy : MonoBehaviour {
	
	public float DestroyTime = 0.5f;
	
	// Use this for initialization
	void Start () {
		// Only destroy the object if time is greater than zero.
		if(DestroyTime > 0)
			Destroy(this.gameObject, DestroyTime);
	}
	
	public void SetTimeToDestroy(float _Time){
		// Only destroy the object if time is greater than zero.
		if(_Time > 0){
			DestroyTime = _Time;
			Destroy(this.gameObject, _Time);
		}
	}
	
	// Destroy inmediatly. Be carefull because there is a DestroyInmediate in Unity's API,
	// that is used to destroy gameobjects in the editor (see Unity's docs).
	public void DestroyInmediate(){
		Destroy(this.gameObject);
	}
	
}
