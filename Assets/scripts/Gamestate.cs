using UnityEngine;
using System.Collections;

public class Gamestate : MonoBehaviour {
	
	
	public static int points = 0;
	public int health = 10;
	public float timer = 5;
	public Vector2 lpoints;
	public Vector2 lhealth;
	public Vector2 ltimer;
	// Use this for initialization
	void OnGUI () {
		GUI.Label(new Rect(lpoints.x,lpoints.y,100,20), "Points "+points);
		GUI.Label(new Rect(lhealth.x,lhealth.y,100,20), "Health "+health);
		GUI.Label(new Rect(ltimer.x,ltimer.y,100,20), "Timer "+timer);
		
		
	}
	
	void Start () {
		InvokeRepeating("Timer",1f,1f);
		health = 10;
		points = 0;
		timer = 20;
	}
	
	void Timer () {
		timer--;
		if (timer <= 0) {
			CancelInvoke();
			health = 0;
			colrock();
			Rock rock = (Rock)MonoBehaviour.FindObjectOfType(System.Type.GetType("Rock"));
			GameObject player = (GameObject)GameObject.FindWithTag("Player");
			PlayerPrefs.SetInt("points",points);
			rock.hitplayer(player.transform.position);
			Invoke("gameover",5);
		}
		
	}
	
	void gameover () {
		Application.LoadLevel("gameover");
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	public void addscore () {
		points++;
	}
	
	public void colrock() {
		health--;
		if (health <= 0) {
			health = 0;
			Destroy(GameObject.FindWithTag("Player"));
		}
	}
}
