//=============================================================================================================
//
// Script : GUIAdjustResolution
// Programador : Julian Oliden. "Jocyf"
//
// Date: 05/04/2013
// Version : 1.3
//
// Description: Adjust a GUI (GUIText or GUITexture can be used) resolution to the screen resolution.
// Note : It doesn't work if change not resolution but also the Aspect Ratio of the screen (4:3, 16:9, etc...)
//
//=============================================================================================================

//=============================================================================================================
//
// Otros scripts en la wiki para escalar GUIs
// http://wiki.unity3d.com/index.php/GUIScaler
// http://wiki.unity3d.com/index.php?title=AspectRatioEnforcer
// http://wiki.unity3d.com/index.php/GuiRatioFixer2
// http://wiki.unity3d.com/index.php/GUIUtils
// Hacer que un GUI sigua a un objeto.
// http://wiki.unity3d.com/index.php/ObjectLabel
//
//=============================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/GUIAdjust")]
public class GUIAdjust : MonoBehaviour {
	
	// Valores originales de los graficos tal y como se crearon para la resolucion destino original.
	public float customWidth = 1024; //Set this value to the Width of your Game Tab in the Editor
	public float customHeight = 768; //Set this value to the Height of your Game Tab in the Editor
	public bool AdjustSize = false;
	public bool AdjustInUpdate = false;
	
	private Rect OrigRect;
	private Vector2 OrigOffset;
	
	// Use this for initialization
	void Awake() {
		if(this.guiTexture != null)
			OrigRect = this.guiTexture.pixelInset;
		else
		if(this.guiText != null)
			OrigOffset = this.guiText.pixelOffset;
		
		AdjustResOneTime();
	}
	
	// Update is called once per frame
	void Update () {
		if(AdjustInUpdate)
			AdjustResOneTime();
	}
	
	public void TextureRatio(){
		
	}
	
	public void AdjustResOneTime(){
		if(this.guiTexture != null)
			this.guiTexture.pixelInset = scaledRect(OrigRect);
		else
		if(this.guiText != null)
			this.guiText.pixelOffset = scaledOffset(OrigOffset);
	}
	
	
	Rect scaledRect (Rect _Rect) {
	    Rect returnRect = _Rect;
	    returnRect.x = (_Rect.x*Screen.width) / customWidth;
	    returnRect.y = (_Rect.y*Screen.height) / customHeight;
		if(AdjustSize){
		    returnRect.width = (_Rect.width*Screen.width) / customWidth;
		    returnRect.height = (_Rect.height*Screen.height) / customHeight;
		}
	    return returnRect;
	}
	
	Vector2 scaledOffset (Vector2 _Offset) {
	    Vector2 returnOffset = _Offset;
	    returnOffset.x = (_Offset.x*Screen.width) / customWidth;
	    returnOffset.y = (_Offset.y*Screen.height) / customHeight;
	   
	    return returnOffset;
	}
	
}
