using UnityEngine;
using System.Collections;

public class Gamestate : MonoBehaviour {
	
	
	public static int points = 0;
	public int health = 10;
	public float timer = 60;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void addscore () {
		points++;
	}
	
	public void colrock() {
		health--;
		if (health <= 0)
			Destroy(GameObject.FindWithTag("Player"));
	}
}
