
// Changed to work in a GUIText too. 02/02/2013

using UnityEngine;
using System.Collections;


[AddComponentMenu( "Utilities/CountDownTimer")]
public class CountDownTimer : MonoBehaviour {
	
	public float startTime = 10; // Start time to countdown from.
	public Rect startRect = new Rect( 290, 10, 150, 30 ); // The rect the time-label is initially displayed at.
	public int WaitTime = 5;  // Time to wait 'till start counting down.
	public Color textColor = Color.white;
	
	private float TimeToCount = 0;
	private string textToDisplay = "";
	private bool IsCountDownFinished = false;
	private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label.
	
	
	public bool IsFinished(){ return IsCountDownFinished; }
	
	// Use this for initialization
	void Start () {
		textToDisplay = FormatTime(startTime); 
		TimeToCount = Time.time + WaitTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(startTime < 0){
			if(!IsCountDownFinished){
				IsCountDownFinished = true;
				textToDisplay = "00:00";
			}
			return;
		}
		
		if(Time.time > TimeToCount){
			startTime -= Time.deltaTime; 
			textToDisplay = FormatTime(startTime); 
		}
		if(guiText)
	    	guiText.text = textToDisplay;
	}
	
	string FormatTime(float time) { 
		int minutes = (int)(time / 60);
		int seconds = (int)time % 60;
		string timeText = string.Format ("{0:00}:{1:00}", minutes, seconds); 
		
		return timeText;
	}
	
	void OnGUI(){
		if(!guiText){
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
}
