using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	
	public float speed = 50f;
	public int limit = 160;
	public Transform explosion;
	public Gamestate gamestate;
	// Use this for initialization
	void Start () {
		gamestate = (Gamestate)GameObject.FindObjectOfType(System.Type.GetType("Gamestate"));
	}
		
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
		if (transform.position.z >= limit) 
			Destroy(gameObject);
			
		
	}
	//collision for trigger
	void OnTriggerEnter (Collider other) {
		
		var findexp = false;
		
		if (other.tag == "rock") {
			
			other.GetComponent<Rock>().respawn();
			/*
			foreach(Explosion exp in GameObject.FindObjectsOfType(System.Type.GetType("Explosion"))) {
				
				if (exp.particleSystem.) {
					explosion = exp.transform;
					explosion.transform.position = gameObject.transform.position;
					explosion.particleSystem.Play();
				
					findexp = true;
					Debug.Log("Cazado uno");
					break;
				}
				
				
			}
			*/
			if (!findexp) {
				Instantiate(explosion,gameObject.transform.position,Quaternion.identity);
				Destroy(gameObject);
				
			}
			
			gamestate.addscore();
			
			
		}
	}
	
}
