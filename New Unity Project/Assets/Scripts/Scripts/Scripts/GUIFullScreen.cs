//====================================================================================================
//
// Script : GUIFullScreen
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Scale a GUITexture to the screen's size.
// 				Get a wrong aspect if changes the ratio of the screen.
//				Depending on the ratio two images shold be used (one for 4:3 an another for 16:9)
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/GUIFullScreen")]
[RequireComponent(typeof(GUITexture))]
public class GUIFullScreen : MonoBehaviour {
	
	public Texture2D texture43; // Ratio : 1.33
	public Texture2D texture169;	// Ratio : 1.77
	public bool AdjustInUpdate = false;
	
	private float ratio = 1.3f;
	
	void Start() {
		this.transform.position = Vector3.zero;
		ratio = (float)Screen.width / (float)Screen.height;
		if(guiTexture){
			guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
			if(ratio < 1.6f)
				guiTexture.texture = texture43;
			else
				guiTexture.texture = texture169;
		}
		
	}
	
	void Update(){
		if(AdjustInUpdate && guiTexture){
			guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
			ratio = (float)Screen.width / (float)Screen.height;
			if(ratio < 1.6f)
				guiTexture.texture = texture43;
			else
				guiTexture.texture = texture169;
		}
	}
}