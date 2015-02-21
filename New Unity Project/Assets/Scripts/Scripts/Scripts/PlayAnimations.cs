//====================================================================================================
//
// Script : PlayAnimations
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Play all the animations stored in the 'Animation' Component.
//				A pauseTime can be used to pause betwen animations.
//
//====================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu( "Utilities/PlayAnimations")]
[RequireComponent(typeof(Animation))]
public class PlayAnimations : MonoBehaviour {
	
	[Range(0, 5)] public float pauseTime = 1;
	[Range(0.1f, 2.0f)] public float playSpeed = 1;
	
	private List<AnimationState> myAnimStates = new List<AnimationState>();
	private float TimeToWait = 0;
	private int count = 0;
	
	// Use this for initialization
	void Start () {
		animation.playAutomatically = false;
		count = animation.GetClipCount();
		getAllAnimations();
	}
	
	// Update is called once per frame
	void Update () {
		PlayAllAnimations();
	}
	
	AnimationState GetAnimationClip (int index){
        int i = 0;

        foreach(AnimationState AnimState in animation){
            if(i == index)
                return AnimState;   
            i++;   
        }
		return null;
    } 
	
	void getAllAnimations(){
		for(int i = 0; i < animation.GetClipCount(); i++)
			myAnimStates.Add(GetAnimationClip(i));
	}
	
	void PlayAllAnimations(){
		if(Time.time >= TimeToWait){
			if(count < animation.GetClipCount()-1)
				count++;
			else
				count = 0;
			
			AnimationState myState = myAnimStates[count];
			//Debug.Log (myState.clip.name+"-"+count);
			myState.speed = playSpeed;
			TimeToWait = Time.time + myState.clip.length+pauseTime;
			animation.Play(myState.clip.name);
        }
		//animation.Stop();
	}
	
	
}
