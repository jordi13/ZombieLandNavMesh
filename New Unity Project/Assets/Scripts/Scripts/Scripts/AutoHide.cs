//====================================================================================================
//
// Script : AutoHide
// Programador : Julian Oliden. "Jocyf"
//
// Date: 06/04/2013
// Version : 1.3
//
// Description: Hides a gameobject, GUItext or GUITexture in the time specified.
// 				The time must be a value greater than zero.
//				To hide inmediatly call HideInmediate() function.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoHide")]
public class AutoHide : MonoBehaviour {
	
	public float delayTime = 0.1f;
	public bool fadeOut = false;	
	public float fadeSpeed = 1;
	public bool isActive = false;
	private bool hasFinished = true;

	// Only hides the object if time is greater than zero.
	void Start() {
		if(isActive){
			StartCoroutine(DelayHide());
		}
	}
	
	
	IEnumerator DelayHide(){
		yield return new WaitForSeconds(delayTime);
		if(!fadeOut)
			InmediateHide();
		else{
			isActive = true;
			hasFinished = false;
		}
	}
	
	void InmediateHide(){
		if(renderer){
			Color _color = renderer.material.GetColor("_Color"); // Normal Transparent shader
			_color.a = 0;
			renderer.material.SetColor("_Color", _color); // Normal Transparent shader
			//renderer.enabled = false;
		}
		else
		if(guiText){
			Color _color = guiText.material.color;
			_color.a = 0;
			guiText.material.color = _color;
			//guiText.enabled = false;
		}
		else
		if(guiTexture){
			Color _color = guiTexture.color;
			_color.a = 0;
			guiTexture.color = _color;
			//guiTexture.enabled = false;
		}
		hasFinished = true;
		isActive = false;
	}
	
	void Update(){
		if(!isActive)
			return;
		
		if(fadeOut && !hasFinished){
			if(guiTexture){
				Color _color = guiTexture.color;
				_color.a = Mathf.Lerp(_color.a, 0F, fadeSpeed*Time.deltaTime);
				if(_color.a < .02F){
					_color.a = 0;
					hasFinished = true;
				}
				guiTexture.color = _color;
			}
			else
			if(guiText){
				Color _color = guiText.material.color;
				_color.a = Mathf.Lerp(_color.a, 0F, fadeSpeed*Time.deltaTime);
				if(_color.a < .02F){
					_color.a = 0;
					hasFinished = true;
				}
				guiText.material.color = _color;
			}
			else
			if(renderer){
				Color _color = renderer.material.GetColor("_Color"); // Normal Transparent shader
				//Color _color = renderer.material.GetColor("_TintColor"); // Use this with Particles shaders
				_color.a = Mathf.Lerp(_color.a, 0F, fadeSpeed*Time.deltaTime);
				if(_color.a < .02F){
					_color.a = 0;
					hasFinished = true;
				}
				renderer.material.SetColor("_Color", _color); // Normal Transparent shader
				//renderer.material.SetColor("_TintColor", _color); // Use this with Particles shaders
			}
		}
		else
		if(fadeOut && hasFinished)
			isActive = false;
	}
	
	
	public void SetTimeToHide(float _Time){
		delayTime = _Time;
		isActive = true;
		if(fadeOut)
			hasFinished = false;
		StartCoroutine(DelayHide());
	}
	
	// Hide inmediatly.
	public void HideInmediate(){
		delayTime = 0;
		isActive = true;
		//fadeOut = false;
		hasFinished = true;
		InmediateHide();
	}
}