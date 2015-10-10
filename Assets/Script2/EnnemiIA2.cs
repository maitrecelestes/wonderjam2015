using UnityEngine;
using System.Collections;

public class EnnemiIA2 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject player;
	private GameObject newEnnemi;
	private Vector2 posInit;
	public Vector2 speed = new Vector2(1, 1);
	private Vector2 posLeft;
	private Vector2 posRight;
	private bool versRight;
	public bool modePoursuite;
	private Vector2 movement;
	
	
	// Use this for initialization
	void Start () {
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi");
		player = GameObject.FindGameObjectWithTag ("Player");
		newEnnemi = GameObject.Find("Ennemi");
		posInit = ennemi.transform.position;
		posLeft= new Vector2 (posInit.x-1, 0);
		
		posRight= new Vector2 (posInit.x+1, 0);
		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 
		if (versRight) {
			versRight=false;
		} 
		else if (!versRight){
			versRight=true;
		}
		if (!modePoursuite) {
			if (versRight) {
				movement = new Vector2 (
					speed.x,
					0);
				
			} else {
				movement = new Vector2 (
					-speed.x,
					0);
			}
		} else {
			if (ennemi.transform.position.x>player.transform.position.x){
				movement = new Vector2 (
					-speed.x,
					0);
			} else {
				movement = new Vector2 (
					speed.x,
					0);
			}
		}
		
		
	}
	
	
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;
		
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (!col.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
			Destroy (col.gameObject);
		}
	}
}