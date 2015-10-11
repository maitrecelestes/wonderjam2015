using UnityEngine;
using System.Collections;

public class PlayerScript5 : MonoBehaviour {


	private Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;

	private GameObject PauseCanvas; 
	private GameObject GameOver; 

	private bool isjumping= false;
	private GameObject Player;
	private float fireRate=1;
	private float nextFire;

	public Sprite[] Images;

	// Use this for initialization
	void Start () {
	
		//images = Resources.LoadAll<Sprite>("Assets/Textures3");

		Player = GameObject.FindGameObjectWithTag ("Player");
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);

	}


	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis("Horizontal");
		movement = new Vector2(
			inputX*speed.x,0);

		if (Input.GetKeyDown ("space")){
			if(isjumping==false){
				movement = new Vector2(
					speed.x * inputX,
					50);
				isjumping=true;
			}
		}

		if (transform.position.y <= 1.10) {
			isjumping = false;
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
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ennemi_niv5") || col.gameObject.CompareTag("EnnemiBolt")) {
			gameObject.SetActive (false);
			Time.timeScale = 0;
			GameOver.SetActive (true);
		}
	}
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}

}
