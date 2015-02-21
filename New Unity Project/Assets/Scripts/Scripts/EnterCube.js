var interval : float=0.5; 
private var nextinterval : float=0.0; 

function OnTriggerEnter (other : Collider) {
	if(other.name == "GunController"){
		GeneralVars.nSalud--;
	}
}

function OnTriggerStay (other : Collider) {
	if(other.name == "GunController"){
		if (Time.time>nextinterval){
			nextinterval = Time.time + interval; 
			GeneralVars.nSalud--;
		}
	}
}