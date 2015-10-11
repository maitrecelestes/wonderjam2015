using UnityEngine;
using System.Collections;

public class PlayerScriptBoss2 : MonoBehaviour {

	
	private Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;
	private bool isjumping= false;
	private GameObject PauseCanvas; 
	public GameObject shot;
	public GameObject shot2;
	public Transform ShotSpawn;
	private float fireRate=1;
	private float nextFire;
	private GameObject GameOver; 
	private GameObject player;
	// Use this for initialization
	void Start () {
		
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
		player = GameObject.Find ("Heros");
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= 0.24) {
			isjumping = false;
		}
		float inputX = Input.GetAxis("Horizontal");
		
		movement = new Vector2(
			speed.x * inputX,
			0);
		
		if (Input.GetKeyDown ("space")){
			if(isjumping==false)
			{
				movement = new Vector2(
					speed.x * inputX,
					75);
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
		if (Input.GetKey (KeyCode.LeftControl) && Time.time > nextFire) {
			Vector3 vector= new Vector3(player.transform.position.x-1,player.transform.position.y,0);
			nextFire = Time.time + fireRate;
			Instantiate (shot2, vector, ShotSpawn.rotation);
		}
		if (Input.GetKey (KeyCode.RightControl) && Time.time > nextFire) {
			Vector3 vector= new Vector3(player.transform.position.x+1,player.transform.position.y,0);
			nextFire = Time.time + fireRate;
			Instantiate (shot, vector, ShotSpawn.rotation);
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
	void OnCollisionEnter2D(Collision2D col)
	{
		isjumping = false;
		if (col.gameObject.CompareTag ("Ennemi_niv3") || col.gameObject.CompareTag("EnnemiBolt")) {
			player.SetActive (false);
			Time.timeScale = 0;
			GameOver.SetActive (true);
		}
	}
}
