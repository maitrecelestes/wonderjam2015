using UnityEngine;
using System.Collections;

public class PlayerScritBoss1 : MonoBehaviour {
	
	/// <summary>
	/// 1 - La vitesse de déplacement
	/// </summary>
	private Vector2 speed = new Vector2(2, 2);
	
	// 2 - Stockage du mouvement
	private Vector2 movement;
	private GameObject PauseCanvas; 
	private GameObject GameOver; 
	private GameObject player;
	private bool isjumping= false;
	bool add=false;
	
	void Start()
	{
		player = GameObject.Find ("Heros");
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);
	}
	void Update()
	{
		if (transform.position.y <= -2) {
			player.SetActive(false);
			Time.timeScale = 0;
			GameOver.SetActive(true);
		}
		if (transform.position.y <= 0.01118645) {
			isjumping = false;
		}
		// 3 - Récupérer les informations du clavier/manette
		float inputX = Input.GetAxis("Horizontal");
		
		movement = new Vector2(
			speed.x * inputX,
			0);
		
		if (Input.GetKeyDown ("space")){
			if(isjumping==false)
			{
				movement = new Vector2(
					speed.x * inputX,
					20);
				isjumping=true;
			}
			
		}
		
		
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				PauseCanvas.SetActive (true);
				Time.timeScale = 0;
			}
			else
			{
				PauseCanvas.SetActive (false);
				Time.timeScale = 1;
			}
		}
		
	}
	
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
		if (add) {
			GetComponent<Rigidbody2D> ().velocity=new Vector2(0,10);
			add=false;
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		isjumping = false;
		float pointCollision = player.transform.position.y;
		Vector2 posEnemi = col.transform.position;
		/*else{
				player.SetActive(false);
				Time.timeScale = 0;
				GameOver.SetActive(true);
			}*/
		if (col.gameObject.CompareTag("Ennemi1")){
			if (0.40 < pointCollision) {
				add=true;
			}
		}
	}
	
}