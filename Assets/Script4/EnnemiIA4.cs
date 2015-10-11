using UnityEngine;
using System.Collections;

public class EnnemiIA4 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject Player;
	private Vector2 speed = new Vector2(5, 5);

	private bool versRight;
	private Vector2 movement;
	private float fireRate=3;
	private int ScoreValue=1;
	private float nextFire;
	public GameObject shot;
	public Transform ShotSpawn;
	private GameController4 gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController=gameControllerObject.GetComponent<GameController4>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi_niv4");
		Player = GameObject.FindGameObjectWithTag ("Player");

		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 
		/*if(transform.position.x-Player.transform.position.x>0)
			movement = new Vector2 (
				-speed.x,
				0);
		else
			movement = new Vector2 (
				speed.x,
				0);*/
		if (transform.position.x - Player.transform.position.x < 20) {
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
			}
		}
		deplacement ();

	}
	
	void deplacement (){
		float moveX = -speed.x;
		float moveY = -speed.y;
		if (Player.transform.position.x + 10 > transform.position.x) {
			moveX=speed.x;
		}
		if (Player.transform.position.y + 2 > transform.position.y) {
			moveY=speed.y;
		}
		movement = new Vector2 (moveX, 0);

	}
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;

		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Bolt")) {
			gameController.AddScore(ScoreValue);
				Destroy (col.gameObject);
				Destroy (gameObject);
			}
			

	}
}