public var Salud : int = 100;
public var Explosion : GameObject;
var flag : boolean = false;

var muerte:GameObject;
//PROVA INSTANCIAR CAIXAS

var caixaPrefabs : GameObject;
var caixaMunicio : GameObject;
////
//PROVA MORT 
private var anim : Animator;
///

var deadReplacement : Transform;


function Start(){
	
	anim = GetComponent(Animator);
 
}
//Prova raycast
function Update(){

	if(Salud <= 0){
		//prova mort 
		//muerte.GetComponent(EnemigoMierder).Muerte();
		Detonate();
		// anim.SetBool("Dead",true);
		///////
		GeneralVars.puntuacion += 75;
		
		if(flag == false){
		
			restarEnemyRestante();
			
			//num aleatorio  para k al morir suelte una caja, 20% probabilidades
			var numAux = Random.Range(0,4);
			
			//tiro la caja si el numero es 0 
			if(numAux == 0){
				
				//50 % de probabilidades entre municion o salud
				var numAux2 = Random.Range(0,2);
				
				if(numAux2 == 0){
				
					Instantiate (caixaPrefabs, EnemyMovement.myPosition, Quaternion.identity);

				}
				
				if(numAux2 == 1){
				
					Instantiate (caixaMunicio, EnemyMovement.myPosition, Quaternion.identity);

				}
			}
			
			
			
			
			}
		flag = true;

	}
}

function restarEnemyRestante(){
	
	MasterSpawnScript.enemiesRestantes = MasterSpawnScript.enemiesRestantes -1;
	
}

//Prova ragdoll
function Detonate () {
	// Destroy ourselves
	Destroy(gameObject);
	
	// Play a dying audio clip
	/*if (dieSound)
		AudioSource.PlayClipAtPoint(dieSound, transform.position);
*/
	// Replace ourselves with the dead body
	if (deadReplacement) {
		var dead : Transform = Instantiate(deadReplacement, transform.position, transform.rotation);
		
		// Copy position & rotation from the old hierarchy into the dead replacement
		CopyTransformsRecurse(transform, dead);
	}
}

static function CopyTransformsRecurse (src : Transform,  dst : Transform) {
	dst.position = src.position;
	dst.rotation = src.rotation;
	
	for (var child : Transform in dst) {
		// Match the transform with the same name
		var curSrc = src.Find(child.name);
		if (curSrc)
			CopyTransformsRecurse(curSrc, child);
	}
}





