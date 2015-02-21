#pragma strict
var objetivo: GameObject;
function Start () {

}

function Update () {

	if (Input.GetButtonDown("Fire1")||Input.GetButtonDown("Fire2")){
		Ataque();
	}

}

function Ataque(){
	
	var saludEnemigo:ManejadordeBlancos = objetivo.GetComponent("Salud");
	//saludEnemigo.DecrementaSalud(-50);
}