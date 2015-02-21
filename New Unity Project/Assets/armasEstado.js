#pragma strict
//var SplashObject:GameObject;
public var Damage:int = 45;
public var nTime : float = 3;

function Start () {
	Destroy(this.gameObject,nTime);
}

function OnCollisionEnter (other:Collision) {
var contacto:ContactPoint = other.contacts[0];
var pos:Vector3 = contacto.point;
var rot:Quaternion = Quaternion.identity;

//Instantiate(SplashObject,pos,rot);
Destroy(gameObject);
}