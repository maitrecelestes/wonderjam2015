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
	
	public GameObject feu;
	public GameObject feu2;
	private GameObject zoneFeu;
	private bool feuActivated=false;

	public Sprite imageG;
	public Sprite imageD;

	// Use this for initialization
	void Start () {
	

		Time.timeScale = 1;
		Player = GameObject.FindGameObjectWithTag ("Player");
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);

		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);

		zoneFeu = GameObject.Find("zoneFeu");
	}


	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis("Horizontal");

		if (inputX<0){
			this.gameObject.GetComponent<SpriteRenderer>().sprite=imageG;
		}
		if (inputX>0){
			this.gameObject.GetComponent<SpriteRenderer>().sprite=imageD;
			
		} 
		if (isjumping) {
			inputX=inputX/2;
		}

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

		if (Input.GetKeyDown (KeyCode.E)) {
			if (feuActivated) {
				Destroy (GameObject.FindGameObjectWithTag ("Fire"));
				feuActivated = false;
			} else {
				Vector2 posFeu = new Vector2 (zoneFeu.transform.position.x+1, zoneFeu.transform.position.y);
				Instantiate (feu, posFeu, Quaternion.identity);
				feuActivated = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (feuActivated) {
				Destroy (GameObject.FindGameObjectWithTag ("Fire"));
				feuActivated = false;
			} else {
				Vector2 posFeu2 = new Vector2 (zoneFeu.transform.position.x-5, zoneFeu.transform.position.y);
				Instantiate (feu2, posFeu2, Quaternion.identity);
				feuActivated = true;
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
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ennemi_niv5") ||col.gameObject.CompareTag ("Ennemi") || col.gameObject.CompareTag("EnnemiBolt")) {
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
