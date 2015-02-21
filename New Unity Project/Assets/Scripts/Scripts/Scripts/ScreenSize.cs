//=============================================================================================================
//
// Script : GUIAdjustResolution
// Programador : Unity's Wiki & Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Adjust a GUI (GUIText or GUITexture can be used) resolution to the screen resolution.
// Note : It doesn't work if change not resolution but also the Aspect Ratio of the screen (4:3, 16:9, etc...)
//
//=============================================================================================================

// Unable to locate the link to the original code & autor.
// Changed to work in a GUIText too. 02/02/2013
// Chaged to display ratio 05/03/2013.

using UnityEngine;
using System.Collections;
 
[AddComponentMenu( "Utilities/ScreenSize")]
public class ScreenSize : MonoBehaviour {
	
	public Rect startRect = new Rect( 100, 10, 215, 30 ); // The rect the window is initially displayed at.
	public bool allowDrag = true; // Do you want to allow the dragging of the FPS window
	public Color color = Color.white; // The color of the GUI,
	public Color textColor = Color.white; // The color of the Text.
 
	private float MyWidth = 0;
	private float MyHeight = 0;
	private string ScreenText;
	
	private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label.
 
 
	void Update () {
		if(MyWidth != Screen.width || MyHeight != Screen.height){
			MyWidth = Screen.width;
			MyHeight = Screen.height;
			ScreenText =  "Screen : "+MyWidth.ToString()+"x"+MyHeight.ToString()+" Ratio:"+(MyWidth/MyHeight).ToString();
			if(guiText)
				guiText.text = ScreenText;
		}
	}
 
 
	void OnGUI(){
		if(!guiText){
			// Copy the default label skin, change the color and the alignement
			if( style == null ){
				style = new GUIStyle( GUI.skin.label );
				//style.normal.textColor = textColor;
				style.alignment = TextAnchor.MiddleCenter;
			}
	 
			style.normal.textColor = textColor;
			GUI.color = color;
			startRect = GUI.Window(0, startRect, DoMyWindowScreen, "");
		}
	}
 
	void DoMyWindowScreen(int windowID){
		GUI.Label( new Rect(0, 0, startRect.width, startRect.height), ScreenText, style );
		if( allowDrag ) GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
}

