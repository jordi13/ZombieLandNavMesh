#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter(other:Collider){

	if(other.tag == "Player"){
	
		// Si la arma seleccionada es la 1
		 if (GunPlayer.numeroArma == 1) {
		 
		 	if(LoadGun.munAct2 == 0){
		 		
		 		LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munAct2 = LoadGun.munAct2 + 5;
				LoadGun.munMax3 = LoadGun.munMax3 + 30;
				LoadGun.munMax4 = LoadGun.munMax4 + 12;
				LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 	
		 	else if(LoadGun.munAct3 == 0){
		 		
		 		LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
				LoadGun.munAct3 = LoadGun.munAct3 + 30;
				LoadGun.munMax4 = LoadGun.munMax4 + 12;
				LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 	
		 	else if(LoadGun.munAct4 == 0){
		 		
		 		LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
				LoadGun.munMax3 = LoadGun.munMax3 + 30;
				LoadGun.munAct4 = LoadGun.munAct4 + 12;
				LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 	
		 	else if(LoadGun.munAct5 == 0){
		 		
		 		LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
				LoadGun.munMax3 = LoadGun.munMax3 + 30;
				LoadGun.munMax4 = LoadGun.munMax4 + 12;
				LoadGun.munAct5 = LoadGun.munAct5 + 8;
		 	
		 	}
		 			 	
		 	else{
		 	
		 		LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
				LoadGun.munMax3 = LoadGun.munMax3 + 30;
				LoadGun.munMax4 = LoadGun.munMax4 + 12;
				LoadGun.munMax5 = LoadGun.munMax5 + 8;
				
				}
		
		 }
		 
		 
		 
	
		 // Si la arma seleccionada es la 2
		 if (GunPlayer.numeroArma == 2) {
		 		
		 		if(LoadGun.munAct1 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 5;
		 			LoadGun.munAct1 = LoadGun.munAct1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct3 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 5;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munAct3 = LoadGun.munAct3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct4 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 5;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munAct4 = LoadGun.munAct4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct5 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 5;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munAct5 = LoadGun.munAct5 + 8;
		 	
		 	}
		 	
		 	
		 	
		 		else{
		 	
		 			LoadGun.municionTotal = LoadGun.municionTotal + 5;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
				
				}		 		
		
		 }
		 
		 
		 // Si la arma seleccionada es la 3
		 
		 if (GunPlayer.numeroArma == 3) {
		 		
		 		if(LoadGun.munAct1 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 			LoadGun.munAct1 = LoadGun.munAct1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct2 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munAct2 = LoadGun.munAct2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct4 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munAct4 = LoadGun.munAct4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct5 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munAct5 = LoadGun.munAct5 + 8;
		 	
		 	}
		 	
		 	
		 	
		 		else{
		 	
		 			LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
				
				}		 		
		
		 }
		 
		 
		 
		  // Si la arma seleccionada es la 4
		 
		 if (GunPlayer.numeroArma == 4) {
		 		
		 		if(LoadGun.munAct1 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 12;
		 			LoadGun.munAct1 = LoadGun.munAct1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct2 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 12;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munAct2 = LoadGun.munAct2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct3 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 12;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munAct3 = LoadGun.munAct3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct5 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 12;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munAct5 = LoadGun.munAct5 + 8;
		 	
		 	}
		 	
		 	
		 	
		 		else{
		 	
		 			LoadGun.municionTotal = LoadGun.municionTotal + 12;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
				
				}		 		
		
		 }
		 
		 
		 
		  // Si la arma seleccionada es la 5
		 
		 if (GunPlayer.numeroArma == 5) {
		 		
		 		if(LoadGun.munAct1 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 8;
		 			LoadGun.munAct1 = LoadGun.munAct1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		else if(LoadGun.munAct2 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 8;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munAct2 = LoadGun.munAct2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 	
		 		else if(LoadGun.munAct3 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 8;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munAct3 = LoadGun.munAct3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 	
		 		else if(LoadGun.munAct4 == 0){
		 		
		 			LoadGun.municionTotal = LoadGun.municionTotal + 8;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munAct4 = LoadGun.munAct4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
		 	
		 	}
		 		
		 	
		 	
		 	
		 		else{
		 	
		 			LoadGun.municionTotal = LoadGun.municionTotal + 8;
		 			LoadGun.munMax1 = LoadGun.munMax1 + 30;
					LoadGun.munMax2 = LoadGun.munMax2 + 5;
					LoadGun.munMax3 = LoadGun.munMax3 + 30;
					LoadGun.munMax4 = LoadGun.munMax4 + 12;
					LoadGun.munMax5 = LoadGun.munMax5 + 8;
				
				}		 		
		
		 }
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 	 ////////////
		 	 /*
		 if (GunPlayer.numeroArma == 3) {
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
		 		LoadGun.municionTotal = LoadGun.municionTotal + 30;
		 		LoadGun.munMax3 = LoadGun.munMax3 + 30;
				LoadGun.munMax4 = LoadGun.munMax4 + 12;
				LoadGun.munMax5 = LoadGun.munMax5 + 8;
		
		 }
		 if (GunPlayer.numeroArma == 4) {
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
				LoadGun.munMax3 = LoadGun.munMax3 + 30;
		 		LoadGun.municionTotal = LoadGun.municionTotal + 12;
		 		LoadGun.munMax4 = LoadGun.munMax4 + 12;
				LoadGun.munMax5 = LoadGun.munMax5 + 8;
		
		 }
		 if (GunPlayer.numeroArma == 5) {
		 		LoadGun.munMax1 = LoadGun.munMax1 + 30;
				LoadGun.munMax2 = LoadGun.munMax2 + 5;
				LoadGun.munMax3 = LoadGun.munMax3 + 30;
				LoadGun.munMax4 = LoadGun.munMax4 + 12;
		 		LoadGun.municionTotal = LoadGun.municionTotal + 8;
		 		LoadGun.munMax5 = LoadGun.munMax5 + 8;

		
		 }
		*/
		////

		Destroy (this.gameObject);

		
		
	}
	
}