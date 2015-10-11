using UnityEngine;
using System.Collections;

public class PlayerScript4 : MonoBehaviour {


	private Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;

	public GameObject shield;
	private bool murActive;

	private GameObject PauseCanvas; 
	private GameObject GameOver; 

	public GameObject shot;
	public GameObject shot2;

	public Transform ShotSpawn;
	private GameObject Player;
	private float fireRate=1;
	private float nextFire;

	public Sprite[] Images;

	// Use this for initialization
	void Start () {
	
		//images = Resources.LoadAll<Sprite>("Assets/Textures3");

		murActive = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);

	}


	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		movement = new Vector2(
			inputX*speed.x,
			inputY*speed.y);
		/*if (inputX<0)
		{
			Player.GetComponent<SpriteRenderer>().sprite = Images[0];

		}
		if (inputX>0)
		{
			Player.GetComponent<SpriteRenderer>().sprite = Images[0];

		} */


		if(Input.GetKeyDown(KeyCode.Z)){
			if (murActive){
				Destroy(GameObject.FindGameObjectWithTag("Shield"));
				murActive=false;
			} else {
				Vector2 posMur= new Vector2(Player.transform.position.x+1,Player.transform.position.y);
				Instantiate (shield, posMur, Quaternion.identity);
				murActive=true;
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
		if (Input.GetKey (KeyCode.RightControl) && Time.time > nextFire && !murActive) {
			Vector3 vector= new Vector3(gameObject.transform.position.x+1,gameObject.transform.position.y,0);
			nextFire = Time.time + fireRate;
			Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
		}
		if (Input.GetKey (KeyCode.LeftControl) && Time.time > nextFire && !murActive) {
			Vector3 vector= new Vector3(gameObject.transform.position.x-1,gameObject.transform.position.y,0);
			nextFire = Time.time + fireRate;
			Instantiate (shot2, vector, ShotSpawn.rotation);
		}

		
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ennemi_niv3") || col.gameObject.CompareTag("EnnemiBolt")) {
			gameObject.SetActive (false);
			Time.timeScale = 0;
			GameOver.SetActive (true);
		}
	}
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
		/*if (add) {
			GetComponent<Rigidbody2D> ().velocity=new Vector2(0,10);
			add=false;
		}*/
	}

}
