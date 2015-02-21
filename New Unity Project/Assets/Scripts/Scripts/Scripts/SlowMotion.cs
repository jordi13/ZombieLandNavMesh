//=============================================================================================================
//
// Script : SlowMotion
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Create a bullet Time effect.
// Changing the value will trigger the effect.
// Setting any initial value will be trigger the effet only when pressing key 'E'.
//
//=============================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/SlowMotion")]
public class SlowMotion : MonoBehaviour {
	
	[Range(0, 2)] public float timeToScale = 0.1f;
	private bool isActive = false;
	
	private float timeScaleOriginal = 1;
	private float previosTimeToScale = 0;
	
	// Use this for initialization
	void Start () {
		timeScaleOriginal = Time.timeScale;
		previosTimeToScale = timeToScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToScale == 1)
			isActive = false;
		
		if(timeToScale != previosTimeToScale)
			isActive = true;
			
		if(Input.GetKeyDown(KeyCode.E))
			isActive = !isActive;
		
		if(isActive && Time.timeScale != timeToScale)
			Time.timeScale = timeToScale;
		else
		if(!isActive && Time.timeScale != timeScaleOriginal)
			Time.timeScale = timeScaleOriginal;
	}
	
	public void SetSlowMotion(bool _active){
		isActive = _active;
	}
}
