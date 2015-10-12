using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss5AI : MonoBehaviour {
	private GameObject Player;
	private Vector2 speed = new Vector2(1, 2);


	private bool isjumping=false;
	private Vector2 movement2;
	private float fireRate=1;
	private float nextFire;
	private int hp=10;
	private int ScoreValue=1;
	private int deplace=0;
	public Sprite imageG;
	public Sprite imageD;
	public GameObject shot;
	public GameObject shot2;
	public Transform ShotSpawn;
	private GameObject Vic;
	public Text text;
	public AudioClip impact;
	
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Vic = GameObject.Find ("VictoryCanvas");
		Vic.SetActive (false);


	}
	
	// Deplacement des ennemis
	void Update () { 
		text.text = "HP: " + hp.ToString();
		if (Time.time > nextFire) {
			if ((transform.position.y <= -1.4 && transform.position.y >= -1.5) || (transform.position.y <= 4.7 && transform.position.y >= 4.6) || (transform.position.y <= 10.7 && transform.position.y >= 10.6) || (transform.position.y <= 1.9 && transform.position.y >= 1.8) || (transform.position.y <= 8 && transform.position.y >= 7.9)) {
				nextFire=Time.time+fireRate;
				if (transform.position.x - Player.transform.position.x > 0) {
					Instantiate (shot2, new Vector3 (gameObject.transform.position.x - 1, gameObject.transform.position.y, 0), ShotSpawn.rotation);
				} else {
					Instantiate (shot, new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, 0), ShotSpawn.rotation);
				}

			}
		}
		if (transform.position.y <= -2)
			deplace = 0;
		if (transform.position.y >= 11)
			deplace = 1;
		if(deplace==0)
			movement2 = new Vector2(0, speed.y);
		if (deplace == 1)
			movement2 = new Vector2 (0, -speed.y);
	}
	

	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = new Vector2 ( 0, movement2.y);

		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Fire")) {
			hp = hp - 1;
			AudioSource audio=gameObject.AddComponent<AudioSource>();
			audio.PlayOneShot(impact);
			if (transform.position.x - Player.transform.position.x > 0) {	
				Vector3 Anchor = new Vector3 (1, 0, 0);
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = imageD;
				transform.position = Anchor;
			} else if (transform.position.x - Player.transform.position.x < 0) {	
				Vector3 Anchor = new Vector3 (22, 0, 0);
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = imageG;
				transform.position = Anchor;
			}
			if (hp == 0) {
				Player.SetActive(false);
				Destroy (gameObject);
				Vic.SetActive(true);
				Time.timeScale = 0;
			}
		}
	
		Destroy (col.gameObject);
			

	}
}