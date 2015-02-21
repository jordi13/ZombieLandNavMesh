#pragma strict

var toolbarInt : int = 0;
// he borrado string "Gun0"
var toolbarStrings : String[] = ["Gun1", "Gun2","Gun3","Gun4","Gun5", "Reload"];


private var sfx:boolean=false;
private var sfxSpeed=2.0;
private var gun:GameObject;

//var bayonet:boolean=true;
var gun01:boolean=true;
var gun02:boolean=false;
var gun03:boolean=false;
var gun04:boolean=false;
var gun05:boolean=false;

//var bayonetPrefab:GameObject;
var Gun01Prefab:GameObject;
var Gun02Prefab:GameObject;
var Gun03Prefab:GameObject;
var Gun04Prefab:GameObject;
var Gun05Prefab:GameObject;

var walkSound: AudioClip;
var jumpSound: AudioClip;
//MUNICIO

static var munAct1 = 30;
static var munMax1 = 30;
static var munAct2 = 5;
static var munMax2 = 5;
static var munAct3 = 30;
static var munMax3 = 30;
static var munAct4 = 12;
static var munMax4 = 12;
static var munAct5 = 8;
static var munMax5 = 8;


static var municionTotal = 30;
static var municionActual = 30;
var numArma = 1;
var diferencia = 0;

var style : GUIStyle;
style.fontSize = 30;
style.normal.textColor = Color.white;


function OnGUI()
{
    GUI.Label(Rect(50, 660, 400, 20), municionActual.ToString()+"  / "+municionTotal.ToString(), style);

}
/////////

function Start () {
loadGun (Gun01Prefab);


}

function LateUpdate () {

 
var getFire=Input.GetButton ("Fire1")||Input.GetButton ("Fire2");
var getMove =Input.GetAxisRaw("Vertical")||Input.GetAxisRaw("Horizontal");
var jump=Input.GetButton ("Jump");


/*if (Input.GetKeyDown ("0"))
{
 Destroy (gun);
 loadGun (bayonetPrefab);
 }*/
 
 ////PROVA RECARGAS CON Y SIN BALAS EN EL CARGADOR
 if(GunPlayer.numeroArma == 1 ){
 
 	if(municionActual == 0 && municionTotal > 0){
 	GunPlayer.reload = true;
 	
 		if(municionTotal >= 30){
 			municionActual = 30 ;
			munAct1 = municionActual;
		
			municionTotal = munMax1 - 30;
			munMax1 = municionTotal;
		
 		}
 		else{
 			municionActual = municionTotal;
 			munAct1 = municionActual;
 		
 			municionTotal = 0;
 			munMax1 = municionTotal;
 	}
 	
 	}
 	if(Input.GetKeyDown("r") && municionTotal > 0 && municionActual < 30){
	 	GunPlayer.reload = true;

	
		if(municionTotal >= 30){
 			
			diferencia = 30 - municionActual;
			municionActual = 30 ;
			munAct1 = municionActual;
		
			municionTotal = munMax1 - diferencia;
			munMax1 = municionTotal;
		
 	}
 	else{
 	 	GunPlayer.reload = true;

 		
 			diferencia = 30 - municionActual;
 		
 			if(municionTotal >= diferencia){
 			
 				municionActual = 30;
 				munAct1 = municionActual;
 		
 				municionTotal = munMax1 - diferencia;
 				munMax1 = municionTotal;
 			}
 			else{
 			
 				municionActual = municionActual + municionTotal;
 				munAct1 = municionActual;
 				
 				municionTotal = 0;
 				munMax1 = municionTotal;
 				
 			}
 		
 	}
		
	}
 	
	
	}
	////////////// 2
	
	
	if(GunPlayer.numeroArma == 2 ){
 
 	if(municionActual == 0 && municionTotal > 0){
 	GunPlayer.reload = true;
 	
 		if(municionTotal >= 5){
 			municionActual = 5 ;
			munAct2 = municionActual;
		
			municionTotal = munMax2 - 5;
			munMax2 = municionTotal;
		
 		}
 		else{
 			municionActual = municionTotal;
 			munAct2 = municionActual;
 		
 			municionTotal = 0;
 			munMax2 = municionTotal;
 	}
 	
 	}
 	if(Input.GetKeyDown("r") && municionTotal > 0 && municionActual < 5){
	 	GunPlayer.reload = true;

	
		if(municionTotal >= 5){
 			
			diferencia = 5 - municionActual;
			municionActual = 5 ;
			munAct2 = municionActual;
		
			municionTotal = munMax2 - diferencia;
			munMax2 = municionTotal;
		
 	}
 	else{
 	 	GunPlayer.reload = true;

 		
 			diferencia = 5 - municionActual;
 		
 			if(municionTotal >= diferencia){
 			
 				municionActual = 5;
 				munAct2 = municionActual;
 		
 				municionTotal = munMax2 - diferencia;
 				munMax2 = municionTotal;
 			}
 			else{
 			
 				municionActual = municionActual + municionTotal;
 				munAct2 = municionActual;
 				
 				municionTotal = 0;
 				munMax2 = municionTotal;
 				
 			}
 		
 	}
		
	}
 	
	
	}
	
	
	
	
	
	///////////////////  3
	
	if(GunPlayer.numeroArma == 3 ){
 
 	if(municionActual == 0 && municionTotal > 0){
 	GunPlayer.reload = true;
 	
 		if(municionTotal >= 30){
 			municionActual = 30 ;
			munAct3 = municionActual;
		
			municionTotal = munMax3 - 30;
			munMax3 = municionTotal;
		
 		}
 		else{
 			municionActual = municionTotal;
 			munAct3 = municionActual;
 		
 			municionTotal = 0;
 			munMax3 = municionTotal;
 	}
 	
 	}
 	if(Input.GetKeyDown("r") && municionTotal > 0 && municionActual < 30){
	 	GunPlayer.reload = true;

	
		if(municionTotal >= 30){
 			
			diferencia = 30 - municionActual;
			municionActual = 30 ;
			munAct3 = municionActual;
		
			municionTotal = munMax3 - diferencia;
			munMax3 = municionTotal;
		
 	}
 	else{
 	 	GunPlayer.reload = true;

 		
 			diferencia = 30 - municionActual;
 		
 			if(municionTotal >= diferencia){
 			
 				municionActual = 30;
 				munAct3 = municionActual;
 		
 				municionTotal = munMax3 - diferencia;
 				munMax3 = municionTotal;
 			}
 			else{
 			
 				municionActual = municionActual + municionTotal;
 				munAct3 = municionActual;
 				
 				municionTotal = 0;
 				munMax3 = municionTotal;
 				
 			}
 		
 	}
		
	}
 	
	
	}
	
	
	
	///////////////////  4
	
	if(GunPlayer.numeroArma == 4 ){
 
 	if(municionActual == 0 && municionTotal > 0){
 	GunPlayer.reload = true;
 	
 		if(municionTotal >= 12){
 			municionActual = 12 ;
			munAct4 = municionActual;
		
			municionTotal = munMax4 - 12;
			munMax4 = municionTotal;
		
 		}
 		else{
 			municionActual = municionTotal;
 			munAct4 = municionActual;
 		
 			municionTotal = 0;
 			munMax4 = municionTotal;
 	}
 	
 	}
 	if(Input.GetKeyDown("r") && municionTotal > 0 && municionActual < 12){
	 	GunPlayer.reload = true;

	
		if(municionTotal >= 12){
 			
			diferencia = 12 - municionActual;
			municionActual = 12 ;
			munAct4 = municionActual;
		
			municionTotal = munMax4 - diferencia;
			munMax4 = municionTotal;
		
 	}
 	else{
 	 	GunPlayer.reload = true;

 		
 			diferencia = 12 - municionActual;
 		
 			if(municionTotal >= diferencia){
 			
 				municionActual = 12;
 				munAct4 = municionActual;
 		
 				municionTotal = munMax4 - diferencia;
 				munMax4 = municionTotal;
 			}
 			else{
 			
 				municionActual = municionActual + municionTotal;
 				munAct4 = municionActual;
 				
 				municionTotal = 0;
 				munMax4 = municionTotal;
 				
 			}
 		
 	}
		
	}
 	
	
	}
	
	
	///////////////////  5
	
	if(GunPlayer.numeroArma == 5 ){
 
 	if(municionActual == 0 && municionTotal > 0){
 	GunPlayer.reload = true;
 	
 		if(municionTotal >= 8){
 			municionActual = 8;
			munAct5 = municionActual;
		
			municionTotal = munMax5 - 8;
			munMax5 = municionTotal;
		
 		}
 		else{
 			municionActual = municionTotal;
 			munAct5 = municionActual;
 		
 			municionTotal = 0;
 			munMax5 = municionTotal;
 	}
 	
 	}
 	if(Input.GetKeyDown("r") && municionTotal > 0 && municionActual < 8){
	 	GunPlayer.reload = true;

	
		if(municionTotal >= 8){
 			
			diferencia = 8 - municionActual;
			municionActual = 8 ;
			munAct5 = municionActual;
		
			municionTotal = munMax5 - diferencia;
			munMax5 = municionTotal;
		
 	}
 	else{
 	 	GunPlayer.reload = true;

 		
 			diferencia = 8 - municionActual;
 		
 			if(municionTotal >= diferencia){
 			
 				municionActual = 8;
 				munAct5 = municionActual;
 		
 				municionTotal = munMax5 - diferencia;
 				munMax5 = municionTotal;
 			}
 			else{
 			
 				municionActual = municionActual + municionTotal;
 				munAct5 = municionActual;
 				
 				municionTotal = 0;
 				munMax5 = municionTotal;
 				
 			}
 		
 	}
		
	}
 	
	
	}
 //////////////
 
if (Input.GetKeyDown ("1"))
{ 
  Destroy (gun);
  loadGun (Gun01Prefab);
  municionActual = munAct1;
  municionTotal = munMax1;
    
 
}
if (Input.GetKeyDown ("2"))
{
  Destroy (gun);
  loadGun (Gun02Prefab);
  municionActual = munAct2;
    municionTotal = munMax2;


 
}
if (Input.GetKeyDown ("3"))
{
  Destroy (gun);
  loadGun (Gun03Prefab);
  municionActual = munAct3;
    municionTotal = munMax3;


 
}

if (Input.GetKeyDown ("4"))
{
  Destroy (gun);
  loadGun (Gun04Prefab);
  municionActual = munAct4;
    municionTotal = munMax4;


}
if (Input.GetKeyDown ("5"))
{
  Destroy (gun);
  loadGun (Gun05Prefab);
  municionActual = munAct5;
    municionTotal = munMax5;


}


if (getMove)
	{
	if (!sfx&& !jump)
	playSound (walkSound,sfxSpeed);

	}
 
if (jump)
	{
	if (!sfx){
	playSound (jumpSound,0.50);
	}
	}
	 
if (!jump&&  getMove==0 &&!getFire)
	{
	

	}
}


function playSound (soundClip:AudioClip, speed:float){

      	this.audio.clip = soundClip;
      	this.audio.pitch=speed; 
 		this.audio.Play();
 		sfx=true;
 		yield WaitForSeconds (soundClip.length/speed);
 		sfx=false;
   }
 
 function waitTime (wTime:float)
 {
 
 yield WaitForSeconds (wTime);
 }
 
 
 function loadGun (gunPrefab:GameObject) {
	gun =Instantiate (gunPrefab, this.transform.localPosition+gunPrefab.transform.localPosition, gunPrefab.transform.localRotation);
 
	gun.transform.parent=this.transform;
	gun.transform.localPosition=gunPrefab.transform.localPosition;
	gun.transform.localRotation=gunPrefab.transform.localRotation;
	
	}
	
	
	