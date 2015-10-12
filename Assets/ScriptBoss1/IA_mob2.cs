using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IA_mob2 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject player;
	private GameObject newEnnemi;
	private GameObject GameOver;
	private GameObject Victory; 
	private int health =5;
	private Vector2 posInit;
	public Vector2 speed = new Vector2(1, 1);
	private Vector2 posLeft;
	private Vector2 posRight;
	private bool versRight;
	public Text text;
	public bool modePoursuite;
	private Vector2 movement;


	void Start () {
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi1");
		player = GameObject.FindGameObjectWithTag ("Player");
		Victory = GameObject.Find ("VictoryCanvas");
		GameOver = GameObject.Find ("GameOver");
		posInit = ennemi.transform.position;
		posLeft= new Vector2 (posInit.x-1, 0);
		Victory.SetActive (false);
		posRight= new Vector2 (posInit.x+1, 0);
		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 
		text.text = "HP: " + health.ToString();

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

		float pointCollision = col.transform.position.y;

		if(col.gameObject.CompareTag("Player")){
			Vector2 posEnemi = ennemi.transform.position;
			if (0.48 < pointCollision) { //On ajoute 0.2 pour prendre en compte la taille de l'ennemi
				health--;

			}
			else
			{
				player.SetActive(false);
				Time.timeScale = 0;
				GameOver.SetActive(true);
			}
			if (health==0){
			

				player.SetActive(false);
				ennemi.gameObject.SetActive(false);
				Victory.SetActive(true);

			}
		}
	}
	
}
