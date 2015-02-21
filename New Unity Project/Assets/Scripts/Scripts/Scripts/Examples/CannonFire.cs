using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {
	
	public Transform puntoDisparo;
	public GameObject bala;
	public float acel = 20;
	public float ratio = 2;
	
	private float internalTime = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time >= internalTime){
			RaycastHit hit;
			if(Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hit, 1000)){
				if(hit.transform.tag == "Player")
					Fire();
			}
		}
	}
	
	void Fire(){
		if(Time.time >= internalTime){
			GameObject CloneFire = (GameObject) Instantiate (bala, puntoDisparo.position, puntoDisparo.rotation);
			CloneFire.rigidbody.AddRelativeForce(new Vector3(0, 0,  acel), ForceMode.VelocityChange);
			internalTime = Time.time + ratio;
		}
	}
}
