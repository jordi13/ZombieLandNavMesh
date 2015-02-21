//===================================================================================
// Script : AutoPlayVideo
// Programador : Julian Oliden 'Jocyf'
//
// Date: 01/02/2013
// Version : 1.4
//
// Description: Play/stop a movietexture just ckicking on the texture itself.
//				Or pressing the 'A' key in the keyboard.
//
// Note : Only work with Pro version.
//
//===================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/AutoPlayVideo")]
public class AutoPlayVideo : MonoBehaviour {

	public bool isPlaying = false;
	private MovieTexture myMovie;
	
	void  Start (){
		myMovie = (MovieTexture)guiTexture.texture;
	}
	
	void Update(){
		// detect when user press the 'A' key in keyboard.
		if(Input.GetKeyDown(KeyCode.A)) // Change "KeyCode.A" to use another keyboard's key
			isPlaying = !isPlaying;
		
		if(isPlaying && !myMovie.isPlaying)
  			myMovie.Play();
		else
		if(!isPlaying && myMovie.isPlaying)
			myMovie.Stop();
	}
	
	// Detect the texture click.
	void OnMouseDown (){
		isPlaying = !isPlaying;
	}

}