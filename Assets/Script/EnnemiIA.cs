using UnityEngine;
using System.Collections;

public class EnnemiIA : MonoBehaviour {
	private GameObject ennemi;
	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;

	// Use this for initialization
	void Start () {
		ennemi = GameObject.Find("Ennemi");
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector2(
			speed.x,
			0);

	}

	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D coll){
		float pointCollision = coll.transform.position.y;
		Vector2 posEnemi = ennemi.transform.position;
		Debug.Log ("pointCollision"+pointCollision);
		Debug.Log ("posEnnemi"+posEnemi.y);

		if (coll.gameObject.tag == "Player" && posEnemi.y < pointCollision) {
			Destroy(ennemi);
		}
	}
}
