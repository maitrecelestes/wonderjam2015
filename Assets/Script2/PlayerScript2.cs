using UnityEngine;
using System.Collections;

public class PlayerScript2 : MonoBehaviour {


	private Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;
	private bool isjumping= false;
	private GameObject PauseCanvas; 
	public GameObject shot;
	public Transform ShotSpawn;
	private float fireRate=1;
	private float nextFire;
	// Use this for initialization
	void Start () {
		
		PauseCanvas = GameObject.Find ("PauseCanvas");
		PauseCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -4.3) {
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
			nextFire = Time.time + fireRate;
			Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
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
