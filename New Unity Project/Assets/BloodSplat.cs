using UnityEngine;
using System.Collections;

public class BloodSplat : MonoBehaviour {
	public Texture2D splat;
	private float alpha = 1;
	public float speed;
	public bool test;
	void OnGUI()
	{
		if (alpha > 0.0)
		{
			Color color = Color.white;
			color.a = alpha;
			GUI.color = color;
			GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), splat);
			alpha -= speed*Time.deltaTime;
	}
}
	
	void ApplyDamage ()
	{
		alpha = 1f;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.H) & test)
		{
			ApplyDamage();
		}
	
	}
}
