using UnityEngine;
using System.Collections;

public class AutoBlink : MonoBehaviour {
	
	public float delayTime = 1;
	private bool isHidding = true;
	
	private float internalTime = 0;
	
	// Get our rotate script component from the door itself (this is the trigger
	// that 'fires' all the opening/closing door functionality).
	void Start() {
		this.SendMessage("SetTimeToHide", .0f);
		internalTime = Time.time + delayTime;
	}
	
	void Update(){
		if(Time.time >= internalTime){
			if(isHidding){
				this.SendMessage("HideInmediate");
				this.SendMessage("SetTimeToShow", .0f);
			}
			else{
				this.SendMessage("ShowInmediate");
				this.SendMessage("SetTimeToHide", .0f);
			}
			isHidding = !isHidding;
			internalTime = Time.time + delayTime;
		}
	}

}
