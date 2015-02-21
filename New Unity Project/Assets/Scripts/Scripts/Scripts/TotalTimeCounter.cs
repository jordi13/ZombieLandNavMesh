
// Changed to work in a GUIText too. 02/02/2013

using UnityEngine;
using System.Collections;

[AddComponentMenu( "Utilities/TotalTimeCounter")]
public class TotalTimeCounter : MonoBehaviour {
	
	public Rect startRect = new Rect( 390, 10, 150, 30 ); // The rect the time-label is initially displayed at.
	public Color textColor = Color.white;
	public int countUntill = 0; // Maximun time to count (then stops). if zero then there is no top.
	public int delayTime = 5;  // Deay time to start counting.
	
	private float internalTime = 0;
	private float TotalTimePlayed = 0;
	private string textToDisplay = "";
	private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label.
	
	
	public bool IsFinished(){ return countUntill != 0 && TotalTimePlayed >= countUntill; }
	
	// Use this for initialization
	void Start () {
		internalTime = Time.time + delayTime;
		textToDisplay = "00:00";
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= internalTime){
			if( (countUntill != 0 && TotalTimePlayed < countUntill) || (countUntill == 0) )
				TotalTimePlayed += Time.deltaTime; 
			textToDisplay = FormatTime(TotalTimePlayed); 
			
		}
	}
	
	string FormatTime(float time) { 
		int minutes = (int)(time / 60);
		int seconds = (int)time % 60;
		string timeText = string.Format ("{0:00}:{1:00}", minutes, seconds); 
		
		return timeText;
	}
	
	void OnGUI(){
		// Copy the default label skin, change the color and the alignement
		if( style == null ){
			style = new GUIStyle( GUI.skin.label );
			style.normal.textColor = textColor;
			style.alignment = TextAnchor.MiddleCenter;
		}
 
		GUI.color = textColor;
		GUI.Label( startRect, textToDisplay, style );
	}
	
}
