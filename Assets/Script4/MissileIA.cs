using UnityEngine;
using System.Collections;

public class MissileIA : MonoBehaviour {

	private GameObject Player;
	private Vector2 speed = new Vector2(5, 5);
	

	private bool versRight;
	private Vector2 movement;




	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}


	void deplacement (){
		float moveX = -speed.x;
		float moveY = -speed.y;
			if (Player.transform.position.x > transform.position.x) {
				moveX = speed.x;
			}
			if (Player.transform.position.y > transform.position.y) {
				moveY = speed.y;
			}
			movement = new Vector2 (moveX, moveY);
		
	}
	// Update is called once per frame
	void Update () {
		deplacement ();
	}
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Bolt")) {
			Destroy (col.gameObject);
		}
		Destroy (gameObject);
	}
}
