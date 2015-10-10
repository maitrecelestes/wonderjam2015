using UnityEngine;

/// <summary>
/// Contrôleur du joueur
/// </summary>
public class PlayerScript : MonoBehaviour
{
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
	int ScoreValue=1;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController=gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
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
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		isjumping = false;
		float pointCollision = player.transform.position.y;
		if(col.gameObject.CompareTag("Ennemi")){
			Vector2 posEnemi = col.transform.position;
			
		if (posEnemi.y+0.08 < pointCollision) { //On ajoute 0.2 pour prendre en compte la taille de l'ennemi
				col.gameObject.SetActive(false);
			
			gameController.AddScore(ScoreValue);
		}
			else
			{
				player.SetActive(false);
				Time.timeScale = 0;
				GameOver.SetActive(true);
			}
		}
	}

}