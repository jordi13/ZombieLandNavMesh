//====================================================================================================
//
// Script : Billboard
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Rotate the gameobject to look forward the target.
//				If not target is selected, the maincamera will be used as target.
// 				The rotation can be smoothed or do it directly.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/Billboard")]
public class Billboard : MonoBehaviour{
	
	public Transform target;
	public bool LerpRotation = false;
	public float rotationSpeed = 6;
	public bool AllowXrotation = true;
	public bool AllowYrotation = true;
	public bool AllowZrotation = true;
	
	private Transform MyTransform;
		
	void Start(){
		if(target == null)
			target = Camera.main.transform;
		MyTransform = this.transform;
	}
	
    void Update(){
		if(LerpRotation){
			Vector3 direction = target.position - MyTransform.position;
			
			if (direction.magnitude < 0.1f)
				return; 
			
			if(!AllowXrotation && !AllowYrotation && AllowZrotation)
				return;
				
			// Rotate towards the target 
			MyTransform.rotation = Quaternion.Slerp (MyTransform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime); 
			
			// Check de axis rotations allowed.
			if(AllowXrotation && AllowYrotation && AllowZrotation)
				return;
			else
			if(AllowXrotation && AllowYrotation && !AllowZrotation)
				MyTransform.eulerAngles = new Vector3(MyTransform.eulerAngles.x, MyTransform.eulerAngles.y, 0f);
			else
			if(AllowXrotation && !AllowYrotation && AllowZrotation)
				MyTransform.eulerAngles = new Vector3(MyTransform.eulerAngles.x, 0f, MyTransform.eulerAngles.z);
			else
			if(AllowXrotation && !AllowYrotation && !AllowZrotation)
				MyTransform.eulerAngles = new Vector3(MyTransform.eulerAngles.x, 0f, 0f);
			else
			if(!AllowXrotation && AllowYrotation && AllowZrotation)
				MyTransform.eulerAngles = new Vector3(0f, MyTransform.eulerAngles.y, MyTransform.eulerAngles.z);
			else
			if(!AllowXrotation && AllowYrotation && !AllowZrotation)
				MyTransform.eulerAngles = new Vector3(0f, MyTransform.eulerAngles.y, 0f);
			else
			if(!AllowXrotation && !AllowYrotation && AllowZrotation)
				MyTransform.eulerAngles = new Vector3(0f, 0f, MyTransform.eulerAngles.z);

		}
		else
			MyTransform.LookAt(target.position);
    }
	
}