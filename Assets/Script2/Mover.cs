using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2(10,0)*speed;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
			Destroy (gameObject);
		if (col.gameObject.tag == "Fire") {
			Destroy (col.gameObject);
		}
	}
}
