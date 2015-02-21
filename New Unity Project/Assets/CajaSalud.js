var maximaVida : int = 100;
//Sonidos
var pickUp: AudioClip;
function Start () {

}

function Update () {

}
function OnTriggerEnter(other:Collider){

	if(other.tag == "Player"){
		
		if(GeneralVars.nSalud >= 50 && GeneralVars.nSalud < 100){
			//playSoundPickUp (pickUp);
			 audio.Play();
			GeneralVars.nSalud = maximaVida;
			Destroy (this.gameObject);
		}
		
		if(GeneralVars.nSalud < 50){
			playSoundPickUp (pickUp);
			GeneralVars.nSalud = GeneralVars.nSalud +50;
			Destroy (this.gameObject);
		}
		
		
	}
	
}
function playSoundPickUp (soundClip:AudioClip){
    this.audio.clip = soundClip;
    this.audio.Play();

   }