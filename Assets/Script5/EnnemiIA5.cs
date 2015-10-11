using UnityEngine;
using System.Collections;

public class EnnemiIA5 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject Player;
	private Vector2 speed = new Vector2(5, 5);


	private int hp=6;
	private bool isjumping=false;
	private Vector2 movement;
	private float fireRate=1;
	private float nextFire;
	private GameObject Vic;
	
	// Use this for initialization
	void Start () {
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi_niv5");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Vic = GameObject.Find ("VictoryCanvas");
		Vic.SetActive (false);


	}
	
	// Deplacement des ennemis
	void Update () { 
		deplacement ();
	}
	
	void deplacement (){

			float moveX = -speed.x;
			
			
		if (Player.transform.position.x > ennemi.transform.position.x) {
			moveX=speed.x;
		}
			
		movement = new Vector2 (moveX, 0);
		if (!isjumping) {
			movement = new Vector2 (
				moveX,
				100);
			isjumping = true;
		}


		if (transform.position.y <= 0.5) {
			isjumping = false;
		}


	}
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;

		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Bolt")) {
				hp=hp-2;
				Destroy (col.gameObject);
			if (hp==0){
				Destroy (ennemi);
				Time.timeScale = 0;
			}
			
		}
	}
}