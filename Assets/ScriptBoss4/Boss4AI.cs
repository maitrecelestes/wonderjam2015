using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss4AI : MonoBehaviour {
	private GameObject Player;
	private Vector2 speed = new Vector2(7, 5);
	public AudioClip impact;
	
	private int hp=20;
	private bool isjumping=false;
	private Vector2 movement;
	private float fireRate=1;
	private float nextFire;
	private GameObject Vic;
	public Text text;
	
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Vic = GameObject.Find ("VictoryCanvas");
		Vic.SetActive (false);
		Time.timeScale = 1;
		
	}
	
	// Deplacement des ennemis
	void Update () { 
		text.text = "HP: " + hp.ToString();
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
		
		
		if (transform.position.y <= -3.8) {
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
			AudioSource audio=gameObject.AddComponent<AudioSource>();
			audio.PlayOneShot(impact);
			Destroy (col.gameObject);
			if (hp==0){
				Destroy (gameObject);
				Player.SetActive(false);
				Vic.SetActive(true);
				Time.timeScale = 0;
			}
			
		}
	}
}