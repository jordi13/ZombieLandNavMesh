#pragma strict
private var nav : NavMeshAgent;    
private var player : Transform; 

function Start () {

    player = GameObject.FindGameObjectWithTag ("Player").transform;
    nav = GetComponent (NavMeshAgent);

}

function Update () {
    
    transform.GetComponent(NavMeshAgent).destination = player.position;

}