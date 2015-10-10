using UnityEngine;
using System.Collections;

public class EnnemiIA3 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject player;
	public Vector2 speed = new Vector2(1, 1);

	private GameObject gameOver;
	private bool versRight;
	public bool modePoursuite;
	private Vector2 movement;
	
	
	// Use this for initialization
	void Start () {
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi_niv3");
		player = GameObject.FindGameObjectWithTag ("Player");
		gameOver = GameObject.Find ("GameOver");

	

		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 

		movement = new Vector2 (
			-speed.x,
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
			player.SetActive(false);
			Time.timeScale = 0;
			gameOver.SetActive(true);
		}
	}
}