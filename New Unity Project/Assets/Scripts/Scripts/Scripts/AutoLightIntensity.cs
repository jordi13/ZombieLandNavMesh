//====================================================================================================
//
// Script : AutoLightIntensity
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.4
//
// Description: Increase, decrease (or both doing a cycle) the intensity of a light at given speed.
//
//
//====================================================================================================

// http://wiki.unity3d.com/index.php/Flickering_Light
// http://wiki.unity3d.com/index.php/Flickering_Light2

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoLightIntensity")]
[RequireComponent(typeof(Light))]
public class AutoLightIntensity : MonoBehaviour {

	[Range(0,8)] public float minIntensity = 0;	// Maximun and Minimun intensity.
	[Range(0,8)] public float maxIntensity = 7;
	public float speed = 1; // the speed the light changes it's intensity
	public float delayTime = 1; // Delay to start increasing/decreasing the intendity.
	public bool isGoingUp = true;  // Start going to máximum)
	public bool isCyclic = true; // Is gonna be a cycle going up & down?
	
	private Light myPointLight;
	private float currentIntensity = 0;
	private float internalTime = 0;
	
	// Use this for initialization
	void Start () {
		myPointLight = GetComponent(typeof(Light)) as Light;
		currentIntensity = myPointLight.intensity;
		internalTime = Time.time + delayTime; // setup the first internal delay timer.
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= internalTime){ // is the time reached our internal delay time?
			if(isGoingUp) // increase the light intensity.
				if(currentIntensity < maxIntensity)
					currentIntensity += speed * Time.deltaTime;
				else{
					currentIntensity = maxIntensity;
					if(isCyclic){
						internalTime = Time.time + delayTime; // setup our internal delay timer.
						isGoingUp = false;
					}
				}
			else
				if(currentIntensity > minIntensity) // decrease the light intensity.
					currentIntensity -= speed * Time.deltaTime;
				else{
					currentIntensity = minIntensity;
					if(isCyclic){
						internalTime = Time.time + delayTime; // setup our internal delay timer.
						isGoingUp = true;
					}
				}
			
			myPointLight.intensity = currentIntensity;
		}
	}
		
}
