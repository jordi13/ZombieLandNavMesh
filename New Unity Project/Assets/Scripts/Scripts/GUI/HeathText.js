
function Update () {
	this.guiText.text = " " + GeneralVars.nSalud.ToString();
	
	if(GeneralVars.nSalud <= 0){
		Application.LoadLevel("Muerte");
	}
}