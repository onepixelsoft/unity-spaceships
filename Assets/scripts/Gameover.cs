using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		
		GUI.BeginGroup(new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 500, 500));
		
		GUI.Box (new Rect(0,0,200,200), "Se te acabo el juego :-");
		GUI.Label(new Rect(10,30,200,200), "Puntos "+PlayerPrefs.GetInt("points"));
		
		if (GUI.Button(new Rect(10,160,80,30), "Reiniciar")) {
			Application.LoadLevel("level1");
		}
		
		if (GUI.Button(new Rect(110,160,80,30), "Menu")) {
			Application.LoadLevel("menu");
		}
		GUI.EndGroup();
	}
}
