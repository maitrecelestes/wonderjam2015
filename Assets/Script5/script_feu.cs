using UnityEngine;
using System.Collections;

public class script_feu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ennemi_niv5")) {
			Destroy (col.gameObject);
		}
	}
}
