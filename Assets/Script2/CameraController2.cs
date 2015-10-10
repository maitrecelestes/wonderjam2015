using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController2 : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;
	
	
	void Start () {
		player = GameObject.Find ("Heros");
		offset = transform.position - player.transform.position;
	}
	
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
