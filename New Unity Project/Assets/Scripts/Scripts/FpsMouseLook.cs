using UnityEngine;
using System.Collections;

public class FpsMouseLook : MonoBehaviour {
	
	public enum RotationAxis {MouseX = 1, MouseY = 2}
	
	public RotationAxis RotXY = RotationAxis.MouseX | RotationAxis.MouseY;
	
		// X Axis
		public float SensitivityX = 400f;
	
		public float MinimumX = -360f;
	
		public float MaximumX = 360f;
	
		private float RotationX = 0f;
	
		// Y Axis
		
		public float SensitivityY = 400f;
	
		public float MinimumY = -500f;
	
		public float MaximumY = 50f;
	
		private float RotationY = 0f;
	
		public Quaternion OriginalRotation;
	
		
	
		
	
	
	
	
	// Use this for initialization
	void Start () {
	
		OriginalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(RotXY == RotationAxis.MouseX){
			
			RotationX += Input.GetAxis("Mouse X") * SensitivityX * Time.deltaTime; 
			
			Quaternion XQuaternion = Quaternion.AngleAxis(RotationX, Vector3.up);
			
			transform.localRotation = OriginalRotation * XQuaternion;
		}
		
		// No hacabat tutorial -->  
	
	}
	
	
}
