private var player : Transform; 
var gunController : GameObject;
              
private var nav : NavMeshAgent;    
           
var damage : int = 20;
var distance;
var speed : float;
static var myPosition;

private var anim : Animator;

var other : BloodSplatJS;

var attack1Sound : AudioClip;


function Awake ()
{
    player = GameObject.FindGameObjectWithTag ("Player").transform;
    gunController = GameObject.FindGameObjectWithTag("Player");
    nav = GetComponent (NavMeshAgent);
	anim = GetComponent(Animator);

}


function Update ()
{

		myPosition = transform.position;
		//SABER QUE ANIMACION EJECUTA
        var stateInfo : AnimatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		
		if(!stateInfo.IsName("death")){
		
  		other = gunController.GetComponent(BloodSplatJS);

        //nav.SetDestination (player.position);
        transform.GetComponent(NavMeshAgent).destination = player.position;
        //nav.destination(player.position);
        
        distance = Vector3.Distance(nav.transform.position,player.transform.position);
        anim.SetFloat("Distance",distance);
        
        speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;
        anim.SetFloat("Speed",speed);
        
        }
                
        if(stateInfo.IsName("death")){

            Debug.Log("Esta muerto");
            nav.enabled = false;
			//rigidbody.isKinematic = false;
		    WaitAndDestroy();

       }
        
     
}

function SacarVidaAttack(){
	GeneralVars.nSalud = GeneralVars.nSalud - damage;
	playSoundAttack(attack1Sound);
}
function bloodSplat(){
	other.ApplyDamage();
}

function playSoundAttack(soundClip:AudioClip){
	this.audio.clip = soundClip;
	this.audio.Play();
}

function WaitAndDestroy(){
   Destroy(gameObject.collider);
   yield WaitForSeconds(2.0);
   Destroy(transform.gameObject);
}
