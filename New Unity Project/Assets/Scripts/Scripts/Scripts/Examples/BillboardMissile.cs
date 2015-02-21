//====================================================================================================
//
// Script : BillboardMissile
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Rotate the missile to look forward the target directly.
//				Changes the rigidbody values to make a missile seeker.
//				Also checks collision to display a Msg.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

public class BillboardMissile : MonoBehaviour{
	
	public float accuracy = 10;
	public float speed = 10;
	
	private Transform target;
	private Transform MyTransform;
		
	void Start(){
		target = GameObject.Find("First Person Controller").transform;
		MyTransform = this.transform;
	}
	
    void Update(){
		
		MyTransform.LookAt(target.position);
		
		//this.rigidbody.velocity = Vector3.zero;
		this.rigidbody.AddRelativeForce(new Vector3(0, 0, accuracy), ForceMode.Force);
		this.rigidbody.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
    }
	
	
	void OnCollisionEnter(Collision collision) {
		if(collision.transform.tag == "Player"){
			Debug.Log("Missile Damage!!!");
		}
	}
	
}