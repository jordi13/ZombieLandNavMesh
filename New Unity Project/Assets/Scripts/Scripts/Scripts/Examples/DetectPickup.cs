using UnityEngine;
using System.Collections;

public class DetectPickup : MonoBehaviour {

	public enum pickupType { Health, Ammo, Mana };
	
	public pickupType type = pickupType.Health;
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			switch (type){
				case pickupType.Health:
					// TO-DO : Add health to the main player.
					// MyPlayer.Health += 10; // Example.
					Debug.Log("DetectPickup : Health picked!.");
					break;
				case pickupType.Ammo:
					// TO-DO : Add ammo to the main player.
					Debug.Log("DetectPickup : Ammo picked!.");
					break;
				case pickupType.Mana:
					// TO-DO : Add mana to the main player.
					Debug.Log("DetectPickup : Mana picked!.");
					break;
				default :
					// TO-DO : ¿do nothing? ¿Display a warning msg?.
					Debug.Log("DetectPickup : This Pickup doesnt have a type.");
					break;
			}
		}
	}
	
}
