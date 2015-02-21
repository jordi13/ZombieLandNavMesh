//====================================================================================================
//
// Script : DrawGizmos
// Programador : Julian Oliden. "Jocyf"
//
// Date: 06/04/2013
// Version : 1.0
//
// Description: Draw icon gizmos in the scene window.
// Obsolete : Unity provides an integrated way to do this.
//
//====================================================================================================

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/DrawGizmos")]
public class DrawGizmos : MonoBehaviour {
	
	public Texture2D icon;
	
	// Implement this OnDrawGizmosSelected
	// if you want to draw gizmos only if the
	// object is selected.
	void OnDrawGizmosSelected () {
		if(icon != null)
			Gizmos.DrawIcon (transform.position, icon.name);
	}
	
	// Implement this OnDrawGizmos if you want
	// to draw gizmos that are also pickable
	// and always drawn.
	void OnDrawGizmos () {
		if(icon != null)
			Gizmos.DrawIcon (transform.position, icon.name);
	}
	
}
