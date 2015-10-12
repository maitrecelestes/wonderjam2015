using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss2AI : MonoBehaviour {
	private GameObject ennemi;
	private GameObject player;
	private Vector2 speed = new Vector2(5, 5);
	
	private int hp=6;
	private bool versRight;
	public bool modePoursuite;
	private Vector2 movement;
	private float fireRate=3;
	private float nextFire=2;
	public GameObject shot;
	public GameObject shot2;
	public Transform ShotSpawn;
	private GameObject Player;
	public Text text;
	private GameObject Vic;

	public Sprite imageG;
	public Sprite imageD;
	public AudioClip impact;

	// Use this for initialization
	void Start () {
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi_niv3");
		player = GameObject.FindGameObjectWithTag ("Player");
		Player = GameObject.Find ("Heros");
		Vic = GameObject.Find ("VictoryCanvas");
		Vic.SetActive (false);
		
		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 
		text.text = "HP: " + hp.ToString();

		if (transform.position.x - Player.transform.position.x > 0) {
			movement = new Vector2 (
				-speed.x,
				0);
			this.gameObject.GetComponent<SpriteRenderer>().sprite=imageG;
			if (Time.time > nextFire) {
				Vector3 vector = new Vector3 (gameObject.transform.position.x - 1, gameObject.transform.position.y, 0);
				nextFire = Time.time + fireRate;
				Instantiate (shot2, vector, ShotSpawn.rotation);
			}
		}
		else{
			movement = new Vector2 (
				speed.x,
				0);
			this.gameObject.GetComponent<SpriteRenderer>().sprite=imageD;
			if (Time.time > nextFire) {
				Vector3 vector = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, 0);
				nextFire = Time.time + fireRate;
				Instantiate (shot, vector, ShotSpawn.rotation);
			}	
		}
	}
	
	
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;
		
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Bolt")) {
			hp=hp-2;
			AudioSource audio=gameObject.AddComponent<AudioSource>();
			audio.PlayOneShot(impact);
			Destroy (col.gameObject);
			if (hp==0){
				Destroy (ennemi);
				player.SetActive(false);
				Vic.SetActive(true);
				Time.timeScale = 0;
			}	
		}
	}
}