#pragma strict
var target : Transform ;

function Start () {
	
}

function Update () {
	
	GetComponent(NavMeshAgent).destination = target.position;
	
	 


}