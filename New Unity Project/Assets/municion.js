#pragma strict
public var municionTotal = 100;
public var municionActual = 10;
var numArma;

var style : GUIStyle;
style.fontSize = 30;
style.normal.textColor = Color.white;
////////


function Start () {



}

function Update () {


}
function reducirMunicion(){
	municionActual --;
}
function OnGUI()
{
    GUI.Label(Rect(700, 10, 400, 20), municionActual.ToString()+"  / "+municionTotal.ToString()+"   "+numArma.ToString(), style);
    
    
    /*if (numArma == 1){
            GUI.Label(Rect(700, 10, 400, 20), munAct.ToString()+numArma.ToString(), style);

    }
    if(numArma == 2){
            GUI.Label(Rect(700, 10, 400, 20), munAct2.ToString()+numArma.ToString(), style);

    }*/

}

function setNumArma(numeroArma : int){
		numArma = numeroArma;

}

function setMunMax(munMax : int){
		municionTotal = munMax;

}

function setMunAct(munAct : int){
		municionActual = munAct;

}