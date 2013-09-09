using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed = 30.0F;
	public int limit = 24;
	public Transform shot;
	public List<Transform> weapons;
	
	
	void Start() {
		//Load weapon and Shot
		
	}
   
    void Update() {
		
		
		//Movement basic
        float transv = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float transh = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(transh,0,transv);
		var pos = transform.position;
		
        //Limits movement with Math.Clamp (Devulve una minimo y maximo de un numero)
		if (pos.x >= limit || pos.x <= -limit) {
			transform.position = new Vector3(Mathf.Clamp(pos.x,-limit,limit),pos.y,pos.z);
		} 
		
		//Weapon and Shot
		if (Input.GetButtonDown("Fire1")) {
			//Instantiate(shot,weapon.position,Quaternion.identity);
			//De esta forma no porque los ejes estan cambiados en el arma
			
			foreach (Transform w in weapons) {
				Instantiate(shot,w.position,w.rotation);
			}
			
		}
		
    }
	
	
	
	
	/*
	void OnCollisionEnter(Collision col) {
		Debug.Log("Colisiona");
	}
	
	void OnControllerColliderHit(Collision hit) {
		Debug.Log("HIT");
	}
	*/
}
