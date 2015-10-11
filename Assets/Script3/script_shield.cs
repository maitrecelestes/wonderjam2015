using UnityEngine;
using System.Collections;

public class script_shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Bolt")) {
			Destroy (col.gameObject);
		}
	}
}
