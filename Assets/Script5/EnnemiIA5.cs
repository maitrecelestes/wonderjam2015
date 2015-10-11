using UnityEngine;
using System.Collections;

public class EnnemiIA5 : MonoBehaviour {
	private GameObject Player;
	private Vector2 speed = new Vector2(5, 5);


	private bool isjumping=false;
	private Vector2 movement;
	private float fireRate=1;
	private float nextFire;
	private GameController5 gameController;
	private int ScoreValue=1;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController=gameControllerObject.GetComponent<GameController5>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
		Player = GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Deplacement des ennemis
	void Update () { 
		deplacement ();
	}
	
	void deplacement (){

			float moveX = -speed.x;
			
			
		if (Player.transform.position.x > transform.position.x) {
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
		if (col.gameObject.CompareTag ("Fire")) {
			Destroy (gameObject);
			gameController.AddScore(ScoreValue);
			}
			

	}
}