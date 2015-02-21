var gunController : GameObject;
var Estado : int = 0;

var Target: GameObject; //El objetivo

private var RotInic : Quaternion;
var RotSpeed : float;

var VelMov : float;
var gravity : float = 9.8;

private var DistanciaCont : float;
var DistEnem : float = 0.5;

private var contador = 0.0;
var damage : int;

//0 vivo , 1 muerto
//var estaMuerto = 0;
private var estaMuerto : boolean = false;
//Animaciones

var IdleAnim : AnimationClip;
var RunAnim : AnimationClip;
var GuardAnim : AnimationClip;
var AttackAnim : AnimationClip;
var AttackAnim2 : AnimationClip;


var MuerteAnim : AnimationClip;

//Sonidos
var attack1: AudioClip;
var attack2: AudioClip;
var muerto: AudioClip;

//PROVA INSTANCIAR CAIXAS
static var myPosition ;




function Start ()
{
	gunController = GameObject.FindGameObjectWithTag("Player");

   //wrapMode puede ser: Once, Loop, PingPong, Default o ClampForever
   animation[IdleAnim.name].speed = 1;
   animation[IdleAnim.name].wrapMode = WrapMode.Loop;

   animation[RunAnim.name].speed = 1;
   animation[RunAnim.name].wrapMode = WrapMode.Loop;

   animation[GuardAnim.name].speed = 1;
   animation[GuardAnim.name].wrapMode = WrapMode.Loop;

   animation[AttackAnim.name].speed = 2;
   animation[AttackAnim.name].wrapMode = WrapMode.Once;
   
   animation[AttackAnim2.name].speed = 2;
   animation[AttackAnim2.name].wrapMode = WrapMode.Once;

   animation[MuerteAnim.name].speed = 1;
   animation[MuerteAnim.name].wrapMode = WrapMode.ClampForever;

   RotInic = transform.rotation;

   animation.Play(IdleAnim.name);
   
   if (Target == null)
   {
      Target = GameObject.FindGameObjectWithTag("Player");
   }

}

function Update () 
{

	//PROVA INSTANCIAR CAIXAS
	
	
	myPosition = transform.position;
	
	////////////
   var other : BloodSplatJS = gunController.GetComponent(BloodSplatJS);
   var controller : CharacterController = GetComponent(CharacterController);

   if (Estado == 0 && estaMuerto == false)
   {
      //Acción	
      //Cambio de Estado y Activar siguiente animación.
      //Se cambia mediante un disparador externo.
   }
   if (Estado == 1 && estaMuerto == false) //Perseguir
   {
      //Acción
      //Girar y avanzar.
    /*  transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), RotSpeed * Time.deltaTime);
      transform.rotation.x = RotInic.x;
      transform.rotation.z = RotInic.z;			*/
      //Cambio de Estado y Activar siguiente animación.
	  
   /*   controller.Move(transform.forward * VelMov * Time.deltaTime);
      //Aplicar gravedad
      controller.Move(transform.up * -gravity * Time.deltaTime);
      */
     
	  
      //Cambio de Estado y Activar siguiente animación.

      DistanciaCont = Vector3.Distance(Target.transform.position, transform.position);
      if (DistanciaCont <= DistEnem)
      {
         Estado = 2;
         animation.CrossFade(GuardAnim.name);
          
      }
   }
   if (Estado == 2 && estaMuerto == false) //Guardia
   {
      //Acción
      //Cambio de Estado y Activar siguiente animación.
      DistanciaCont = Vector3.Distance(Target.transform.position, transform.position);
      if (DistanciaCont > DistEnem)
      {
         Estado = 1; //Pasa al estado de perseguir.
         animation.CrossFade(RunAnim.name);
         
      }if(DistanciaCont < DistEnem){
         Estado = 3;//Pasa al estado de Atacar.
         
         //Hago un Random para variar entre las animaciones de ataque
         //Pongo entre 0 y 2 porque Random.Range excluye el valor max , por tanto es entre 0 y 1
         var aux = Random.Range(0,2);
         if (aux == 0){
         	contador = Time.time + (animation[AttackAnim.name].clip.length * 0.8);
         	//El tiempo actual + (el tiempo de la animación y un pelín más)
         	animation.Play(AttackAnim.name);	
         		
         			//Restar vida con delay
		 			SacarVidaAttack();
		 			//Aplicar Blood Splat
					other.ApplyDamage(); 
					//BloodSplatJS.ApplyDamage();
					//Sonido ataque 1
					playSoundAttack (attack1);
					

         		
         }
         
         if (aux == 1){
         	contador = Time.time + (animation[AttackAnim2.name].clip.length * 0.8);
         	//El tiempo actual + (el tiempo de la animación y un pelín más)
         	animation.Play(AttackAnim2.name);	
         		
         			//Restar vida con delay
		 			SacarVidaAttack();
		 			//Aplicar Blood Splat
					other.ApplyDamage();
					//BloodSplatJS.ApplyDamage();
					//Sonido ataque 2
					playSoundAttack (attack2); 
         		
         		
         }
         
      }
   }
   if (Estado == 3 && estaMuerto == false) // Atacar
   {
      //Acción
   
      //Cambio de Estado y Activar siguiente animación.
      if (Time.time > contador)
      {
         Estado = 2;
         animation.CrossFade(GuardAnim.name, 2.0f);
      }
   }
   
   
   
}


function SacarVidaAttack()
{
		//Delay de la animación y resto vida 
		yield WaitForSeconds(0.7); 
    	GeneralVars.nSalud = GeneralVars.nSalud - damage;
}

function playSoundAttack (soundClip:AudioClip){
   this.audio.clip = soundClip;
    yield WaitForSeconds (0.5);
    this.audio.Play();

   }
   
function playSoundMuerte (soundClip:AudioClip){
   this.audio.clip = soundClip;
   // yield WaitForSeconds (0.5);
    this.audio.Play();

   }


function Muerte ()
{
	
   Estado =9;
   animation.Play (MuerteAnim.name);
   estaMuerto = true;
   playSoundMuerte(muerto);
   WaitAndDestroy();
}

function DoActivateTrigger ()
{	
	if (estaMuerto == false){
   Estado = 1;
   animation.CrossFade(RunAnim.name);
   }
}

function DoDesactivateTrigger ()
{
	if (estaMuerto == false){
   Estado = 0; //cambiar a al estado de Inactivo
   animation.Play(IdleAnim.name);
   }
}

function WaitAndDestroy(){
   Destroy(gameObject.collider);
   yield WaitForSeconds(2.0);
   Destroy(transform.parent.gameObject);
}