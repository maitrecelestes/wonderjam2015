using UnityEngine;
using System.Collections;

public class EnnemiIA25 : MonoBehaviour {
	private Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;
	int ScoreValue=1;
	private GameController5 gameController;
	private GameObject Player;
	
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController=gameControllerObject.GetComponent<GameController5>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
		Player = GameObject.Find ("Heros");
	}
	
	// Deplacement des ennemis
	void Update () { 
		if(transform.position.x-Player.transform.position.x>0)
			movement = new Vector2 (
				-speed.x,
				0);
		else
			movement = new Vector2 (
				speed.x,
				0);
		
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
			gameController.AddScore(ScoreValue);
		}
	}
}