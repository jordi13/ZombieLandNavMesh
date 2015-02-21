#pragma strict
private var sfx:boolean=false;
private var afx:boolean=false;
private var bfx:boolean=false;
private var Rcnt=0;
var GChange:boolean=false;

private var GunFireSpr:GameObject;
private var idleCnt:int=0;
private var GunFireLight:Light; 

static var reload:boolean=false;

var startClip:AnimationClip;
var idleClip:AnimationClip;
var walkClip:AnimationClip;
var attackClip:AnimationClip; 
var shootClip:AnimationClip;
var oneShootClip:AnimationClip;
var reloadClip:AnimationClip;

private var gunStart:boolean=false;

var attackSound: AudioClip;
var shootSound: AudioClip;
var reloadSound: AudioClip;

var animSpeed:float=1.0;
var prefabBullet:Transform;

static var reloadKey=false;

//Prova raycast
public var SplashObject : GameObject;
public var UseRotation : boolean;
public var damageArma : int;
//////////
//Prova municion
private var propArmas : LoadGun;
private var Armas : GameObject[];
static var numeroArma;
public var municionTotal : int = 40;
public var municionActual : int = 15; 
var contadorProva = 0;

var GunPrefab : GameObject;

function Start () {


/////
gunStart=false;
if (GameObject.Find ("GunFire"))
	{
  	GunFireSpr=GameObject.Find ("GunFire");
  	GunFireLight=GameObject.Find ("GunFireLight").GetComponent(Light); 
	GunFireSpr.renderer.enabled=false;
	GunFireLight.intensity=0;
	}
	
	setClips();
	setAnimSpeed(animSpeed);



if (startClip) {
 this.animation.Play  (startClip.name); 
 yield WaitForSeconds (startClip.length);
 gunStart=true;
 }
 
 }

function LateUpdate () {

//PROVA MUNICIO
if (GameObject.Find("Gun01Start(Clone)")){
		numeroArma = 1;
      
       }
       
       if (GameObject.Find("Gun02Start(Clone)")){
		numeroArma = 2;
        
       }
       
       if (GameObject.Find("Gun03Start(Clone)")){
		numeroArma = 3;
        
       }
       
       if (GameObject.Find("Gun04Start(Clone)")){
		numeroArma = 4;
        
       }
       
       if (GameObject.Find("Gun05Start(Clone)")){
		numeroArma = 5;
        
       }
////////////////////////
if (GChange){

 		gunStart=false;
 		if (!afx){
 		animBlend( startClip);
 		playAnim ( startClip);
 		}
 		
	}	
	
if (gunStart){
		if (GameObject.Find ("GunFire"))
			{
			GunFireSpr=GameObject.Find ("GunFire");
  			GunFireLight=GameObject.Find ("GunFireLight").GetComponent(Light); 
	 	 	GunFireSpr.renderer.enabled=false;
		 	GunFireLight.intensity=0;
		 	}

reloadKey=Input.GetKeyDown ("r");

if (reloadKey){
	//reload=true;
	Rcnt=0;
	}
	
	

	
var getFire=(Input.GetButton ("Fire1")||Input.GetButton ("Fire2"));
var getMove=(Input.GetAxisRaw("Vertical")||Input.GetAxisRaw("Horizontal"));
var jump=Input.GetButton ("Jump");

 if (this.reload){
	if (reloadClip){
		if (!sfx&& Rcnt==0){
		playSound (reloadSound);
		animBlend( reloadClip);
 		playAnim ( reloadClip);
		Rcnt++;
			}
 		}
 		idleCnt=0;
	}

  
  if (!jump&&  getMove==0 &&!getFire&& !sfx)
	{
	idleCnt++;
	animBlend( idleClip);
	if (idleCnt>100){
		animBlend( idleClip);
 		playAnim ( idleClip);
	}
}
  
  
if ( getMove && !getFire && reload==false){

	if ( walkClip){
 		animBlend( walkClip);
 		playAnim ( walkClip);
		idleCnt=0;
		}
	}
	
 
if (getFire && reload==false)
{
	if (attackClip){
		playSound (attackSound);
 		animBlend( attackClip);
 		playAnim ( attackClip);
 		idleCnt=0;
 		}
 	else {
 	
 			if (oneShootClip && LoadGun.municionActual > 0)
 			{
 				
 			if (!bfx){
 				oneGunFire();
 				oneShoot();
 				onePlaySound (shootSound);
 				oneGunFire();
 				}
 				
 				if (!bfx)
 					
 					animBlend(oneShootClip);
 					playAnim (oneShootClip);
 	
 					}
 	
 	    //if (shootClip)
 		if (shootClip && LoadGun.municionActual > 0)
 		{
 			gunFire();
 			if (!bfx )
 				shoot();

 				
 		if (!sfx)
 		playSound (shootSound);
 		animBlend(shootClip);
 		playAnim (shootClip);
 		
 	
 			}
 			idleCnt=0;
	 	}
	}
	
 }

}


function setClips(){
	
	if (startClip)
	this.animation.AddClip(startClip, startClip.name);
	if (idleClip)
	this.animation.AddClip(idleClip, idleClip.name);
	if (walkClip)
	this.animation.AddClip(walkClip, walkClip.name);
	
	if (attackClip)
	this.animation.AddClip(attackClip, attackClip.name);
	
	if (shootClip)
	this.animation.AddClip(shootClip, shootClip.name);
	
	if (oneShootClip)
	this.animation.AddClip(oneShootClip, oneShootClip.name);
	
	
	if (reloadClip)
	this.animation.AddClip(reloadClip, reloadClip.name);

}


function setAnimSpeed (speed:float)
{
for (var state : AnimationState in animation) {
    state.speed = speed;
	}
}

function playAnim(animName:AnimationClip)
{
 afx=true;
this.animation.Play(animName.name);
yield WaitForSeconds (animName.length);
afx=false;
if (animName==reloadClip){
reload=false;
Rcnt=0;
}
}

function animBlend(animName:AnimationClip)
{
this.animation.CrossFadeQueued(animName.name, 0.2);
yield WaitForSeconds (0.2);

}


function playSound (soundClip:AudioClip){
   this.audio.clip = soundClip;
 	this.audio.Play();
 	sfx=true;
    yield WaitForSeconds (soundClip.length);
    sfx=false;
   }
 
 
 function onePlaySound (soundClip:AudioClip){
   this.audio.clip = soundClip;
 	this.audio.Play();
 	sfx=true;
    yield WaitForSeconds (oneShootClip.length);
    sfx=false;
   }
 
 
 function oneGunFire (){
 
 GunFireSpr.renderer.enabled=true;
 GunFireLight.intensity=7.0;
 
 }

 
function gunFire (){
var range= Random.RandomRange (0,2);
	
 if (range){
	 GunFireSpr.renderer.enabled=true;


 }
 else 
	GunFireSpr.renderer.enabled=false;
	GunFireLight.intensity=Random.RandomRange (0,8.0);

 }
 
 function shoot()
 {
       // var instanceBullet = Instantiate(prefabBullet, GunFireSpr.transform.position , Quaternion.identity);
       // instanceBullet.rigidbody.AddRelativeForce ((GameObject.Find ("GunCamera").transform.forward) * 300 );
      
        //RAYCAST
       var hit : RaycastHit;
       if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,hit,1000)){
       	var pos : Vector3 = hit.point;
       	var rot : Quaternion = Quaternion.identity;
       	if(UseRotation == true){
       		rot = Quaternion.FromToRotation(Vector3.up,hit.normal);
       	}
       	
		Instantiate(SplashObject,pos,rot);      
		 	
		 	
       }
       
       if(hit.collider.gameObject.tag == "Enemy"){
       	var BlancosScript : ManejadordeBlancos = hit.collider.gameObject.GetComponent(ManejadordeBlancos);
       	BlancosScript.Salud = BlancosScript.Salud - damageArma;
       	

       }
       /////////////////////
      
       municionActual --;
      
       if (numeroArma == 1){
       LoadGun.munAct1 = LoadGun.munAct1 -1;
       LoadGun.municionActual = LoadGun.munAct1;
       
       }
       if (numeroArma == 2){
       LoadGun.munAct2 = LoadGun.munAct2 -1;
       LoadGun.municionActual = LoadGun.munAct2;
       
       }
       if (numeroArma == 3){
       LoadGun.munAct3 = LoadGun.munAct3 -1;
       LoadGun.municionActual = LoadGun.munAct3;
    
       }
       if (numeroArma == 4){
       LoadGun.munAct4= LoadGun.munAct4 -1;
       LoadGun.municionActual = LoadGun.munAct4;
    
       }
       if (numeroArma == 5){
       LoadGun.munAct5 = LoadGun.munAct5 -1;
       LoadGun.municionActual = LoadGun.munAct5;
    
       }
        ///////////////
        bfx=true;
   		yield WaitForSeconds (0.1);
   		bfx=false;
    }

  function oneShoot()
 {
       // var instanceBullet = Instantiate(prefabBullet, GunFireSpr.transform.position , Quaternion.identity);
       //instanceBullet.rigidbody.AddRelativeForce ((GameObject.Find ("GunCamera").transform.forward) * 300 );
       
       //RAYCAST
       var hit : RaycastHit;
       if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,hit,1000)){
       	var pos : Vector3 = hit.point;
       	var rot : Quaternion = Quaternion.identity;
       	if(UseRotation == true){
       		rot = Quaternion.FromToRotation(Vector3.up,hit.normal);
       	}
       	
		Instantiate(SplashObject,pos,rot);      
		 	
       }

       
       if(hit.collider.gameObject.tag == "Enemy"){
        Debug.Log("Entra");
       	var BlancosScript : ManejadordeBlancos = hit.collider.gameObject.GetComponent(ManejadordeBlancos);
        BlancosScript.Salud = BlancosScript.Salud - damageArma;
       }
       /////////////////////
       
       municionActual --;
      
       if (numeroArma == 1){
       LoadGun.munAct1 = LoadGun.munAct1 -1;
       LoadGun.municionActual = LoadGun.munAct1;

       }
       
       if (numeroArma == 2){
       LoadGun.munAct2 = LoadGun.munAct2 -1;
       LoadGun.municionActual = LoadGun.munAct2;
     
       }
       
       if (numeroArma == 3){
       LoadGun.munAct3 = LoadGun.munAct3 -1;
       LoadGun.municionActual = LoadGun.munAct3;
    
       }
       if (numeroArma == 4){
       LoadGun.munAct4= LoadGun.munAct4 -1;
       LoadGun.municionActual = LoadGun.munAct4;
    
       }
       
       if (numeroArma == 5){
       LoadGun.munAct5 = LoadGun.munAct5 -1;
       LoadGun.municionActual = LoadGun.munAct5;
       }

       //////////////////
       
        bfx=true;
        oneGunFire ();
   		yield WaitForSeconds (oneShootClip.length);
   		bfx=false;
    }
 