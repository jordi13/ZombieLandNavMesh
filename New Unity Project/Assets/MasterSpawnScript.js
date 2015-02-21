#pragma strict

var spawnPoints : Transform[];
var enemyPrefabs : GameObject;

var yieldTimeMin = 1;
var yieldTimeMax = 10;

static var enemyCounter = 0;

var spawnXOffsetMin = 0;
var spawnXOffsetMax = 0;

var spawnZOffsetMin = 0;
var spawnZOffsetMax = 0;

var defaultSpawnNumber = 1;

static var waveNumber = 0;

var isSpawning = false;

var numEnemies;

static var enemiesRestantes;

static var spawnNum = 0;


function SpawnEnemies(wave : int){
	
	spawnNum = (defaultSpawnNumber + 20 * (wave));
	enemiesRestantes = spawnNum;
	
	isSpawning = true;
	
	for(var i = 0; i < spawnNum; i++){
		
		yield WaitForSeconds(Random.Range(yieldTimeMin, yieldTimeMax));
		
		var object : GameObject = enemyPrefabs; 
		var position : Transform = spawnPoints [Random.Range(0,spawnPoints.Length)];
		
		Instantiate(object, position.position + 
			Vector3(Random.Range(spawnXOffsetMin, spawnXOffsetMax),0,
				Random.Range(spawnZOffsetMin, spawnZOffsetMax)), position.rotation);
				
		enemyCounter ++;
		Debug.Log(enemyCounter);
	}
	
	isSpawning = false;
	
}

function UpdateWave(){
	Debug.Log("Wave number : "+waveNumber);
	Debug.Log("Enemy counter : "+enemyCounter);
	waveNumber = waveNumber + 1;
	SpawnEnemies(waveNumber);
	
}
function Start () {
	
}

function detectarMuertos(){

	if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
		enemyCounter = 0;		
	}

}

function Update () {

	if(enemyCounter == 0 && !isSpawning){
		UpdateWave();
	}
	Debug.Log("enemigos restantes ====>>>>  "+GameObject.FindGameObjectsWithTag("Enemy").Length);
	detectarMuertos();
	Debug.Log("Hay --> "+enemyCounter+ "enemies");
	Debug.Log("SpawnNum --> "+spawnNum);
			
	
}

function OnGUI () {
		GUI.Label (Rect (600, 10, 450, 20),"Enemigos Restantes : "+enemiesRestantes);
		GUI.Label (Rect (600, 50, 450, 20),"Enemigos Totales Oleada: "+spawnNum);
		GUI.Label (Rect (600, 30, 450, 20),"Numero Oleada : "+waveNumber);
	}
	
	
