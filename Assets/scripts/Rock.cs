using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	
	public float speed = -12f;
	public int limit = -15;
	public Transform explosion;
	public Gamestate gamestate;
	// Use this for initialization
	void Start () {
		gamestate = (Gamestate)GameObject.FindObjectOfType(System.Type.GetType("Gamestate"));
		respawn();
		//iTween.RotateBy(gameObject, iTween.Hash("z", 1, "y", 1, "time",15, "loopType",iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(Vector3.forward*speed*Time.deltaTime);
		gameObject.transform.Translate(Vector3.back*speed*Time.deltaTime);
		if (gameObject.transform.position.z <= limit)
			respawn();
	}
	
	public void respawn () {
		
		
		Vector3 random = new Vector3(Random.Range(-10,10),Random.Range(-20,20),Random.Range(180,215));
		transform.position = random;
		
		//iTween.MoveTo(gameObject,iTween.Hash("z",limit,"time",Random.Range(3,6),"speed",60,"looptype",iTween.LoopType.none,"oncomplete","respawn", "onupdate", "rotateAroundToValue"));
		//iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 30,"onupdate", "rotateAroundToValue",  "time", 60, "oncomplete", "respawn"));
		
	}
	
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "Player") {
			
			
			Instantiate(explosion,gameObject.transform.position,Quaternion.identity);
			respawn();
			gamestate.colrock();
		}
	}
	
	
 
 
	void rotateAroundToValue()
	{
	    
	    gameObject.transform.Rotate(new Vector3(0,0,1));
		
		
	}
	/*
	void OnCollisionEnter(Collision col) {
		Debug.Log("Colisiona ROCA");
	}
	*/
}
