//====================================================================================================
//
// Script : CursorManager
// Programador : Julian Oliden. "Jocyf"
//
// Date: 06/04/2013
// Version : 1.0
//
// Description: Make the mouse cursor dissapear and lock it at the center of the screen
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/CursorManager")]
public class CursorManager : MonoBehaviour {
	
	public bool ShowCursor = true;
	
	// Update is called once per frame
	void Update () {
		Screen.showCursor = ShowCursor;
		Screen.lockCursor = !ShowCursor;
	}
}
