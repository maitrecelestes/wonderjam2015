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

	private float jumpHeight;
	private bool isjumping= false;

	void Start()
	{
		jumpHeight = 20;
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
	}
	void Update()
	{
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
				jumpHeight);
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
	}

}