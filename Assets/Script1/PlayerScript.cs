using UnityEngine;
using UnityEngine.UI;

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
	private GameObject wall;
	private bool isjumping= false;
	int ScoreValue=1;
	private GameController gameController;
	int i=0;
	private GameObject BossText;
	private GameObject BossText2;
	bool add=false;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController=gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
		BossText = GameObject.Find ("TextBoss");
		BossText.SetActive (false);
		BossText2 = GameObject.Find ("TextBoss2");
		BossText2.SetActive (false);
		wall = GameObject.Find ("WallDes");
		player = GameObject.Find ("Heros");
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);
	}
	void Update()
	{
		if (transform.position.x > 16.3 && transform.position.x < 16.8 && wall.activeSelf)
			BossText.SetActive (true);
		else
			BossText.SetActive (false);
		if (transform.position.x > 17 && transform.position.x < 18)
			BossText2.SetActive (true);
		else
			BossText2.SetActive (false);
		if (transform.position.x > 18.2)
			Application.LoadLevel (2);
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
		if(col.gameObject.CompareTag("Ennemi")){
			
			if (posEnemi.y+0.08 < pointCollision) { //On ajoute 0.2 pour prendre en compte la taille de l'ennemi
				
				add=true;
				col.gameObject.SetActive(false);
				i++;
				gameController.AddScore(ScoreValue);
				if (i==11){
					wall.SetActive(false);
				}
			}/*else{
				player.SetActive(false);
				Time.timeScale = 0;
				GameOver.SetActive(true);
			}*/
		} else if (col.gameObject.CompareTag("Ennemi1")){
			if (0.40 < pointCollision) {
				add=true;
			}
		}
	}
	
}