function OnMouseDown(){
	
	Debug.Log("Jugar pulsado");
	Application.LoadLevel("Ciudad-0");
	
	GeneralVars.nSalud = 100;
	GeneralVars.puntuacion = 0;
	MasterSpawnScript.defaultSpawnNumber = 1;
	MasterSpawnScript.waveNumber = 0;

}