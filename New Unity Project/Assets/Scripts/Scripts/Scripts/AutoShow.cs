//====================================================================================================
//
// Script : AutoShow
// Programador : Julian Oliden. "Jocyf"
//
// Date: 06/04/2013
// Version : 1.3
//
// Description: Shows a gameobject, GUItext or GUITexture in the time specified.
// 				The time must be a value greater than zero.
//				To show inmediatly call ShowInmediate() function.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoShow")]
public class AutoShow : MonoBehaviour {
	
	public float delayTime = 0;
	public bool fadeIn = false;
	public float fadeSpeed = 1;
	public bool isActive = false;
	private bool hasFinished = true;

	// Only shows the object if time is greater than zero.
	void Start() {
		if(isActive)
			StartCoroutine(DelayShow());
	}
	
	
	IEnumerator DelayShow(){
		yield return new WaitForSeconds(delayTime);
		if(!fadeIn)
			InmediateShow();
		else{
			isActive = true;
			hasFinished = false;
		}
	}
	
	void InmediateShow(){
		if(renderer){
			Color _color = renderer.material.GetColor("_Color"); // Normal Transparent shader
			_color.a = 1;
			renderer.material.SetColor("_Color", _color); // Normal Transparent shader
			//renderer.enabled = true;
		}
		else
		if(guiText){
			Color _color = guiText.material.color;
			_color.a = 1;
			guiText.material.color = _color;
			//guiText.enabled = true;
		}
		else
		if(guiTexture){
			Color _color = guiTexture.color;
			_color.a = 1;
			guiTexture.color = _color;
			//guiTexture.enabled = true;
		}
		hasFinished = true;
		isActive = false;
	}
	
	void Update(){
		if(!isActive)
			return;
		
		if(fadeIn && !hasFinished){
			if(guiTexture){
				Color _color = guiTexture.color;
				_color.a = Mathf.Lerp(_color.a, 1F, fadeSpeed*Time.deltaTime);
				if(_color.a > .98F){
					_color.a = 1;
					hasFinished = true;
				}
				guiTexture.color = _color;
			}
			else
			if(guiText){
				Color _color = guiText.material.color;
				_color.a = Mathf.Lerp(_color.a, 1F, fadeSpeed*Time.deltaTime);
				if(_color.a > .98F){
					_color.a = 1;
					hasFinished = true;
				}
				guiText.material.color = _color;
			}
			else
			if(renderer){
				Color _color = renderer.material.GetColor("_Color"); // Normal Transparent shader
				//Color _color = renderer.material.GetColor("_TintColor"); // Use this with Particles shaders
				_color.a = Mathf.Lerp(_color.a, 1F, fadeSpeed*Time.deltaTime);
				if(_color.a > .98F){
					_color.a = 1;
					hasFinished = true;
				}
				renderer.material.SetColor("_Color", _color); // Normal Transparent shader
				//renderer.material.SetColor("_TintColor", _color); // Use this with Particles shaders
			}
		}
		else
		if(fadeIn && hasFinished)
			isActive = false;
	}
	
	
	public void SetTimeToShow(float _Time){
		isActive = true;
		delayTime = _Time;
		if(fadeIn)
			hasFinished = false;
		StartCoroutine(DelayShow());
	}
	
	// Show inmediatly.
	public void ShowInmediate(){
		delayTime = 0;
		isActive = true;
		//fadeIn = false;
		hasFinished = true;
		InmediateShow();
	}
}