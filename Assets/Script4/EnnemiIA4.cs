﻿using UnityEngine;
using System.Collections;

public class EnnemiIA4 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject Player;
	private Vector2 speed = new Vector2(5, 5);

	private int hp=6;
	private bool versRight;
	private Vector2 movement;
	private float fireRate=1;
	private float nextFire;
	public GameObject shot;
	public Transform ShotSpawn;
	private GameObject Vic;
	
	// Use this for initialization
	void Start () {
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi_niv4");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Vic = GameObject.Find ("VictoryCanvas");
		Vic.SetActive (false);

		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 
		/*if(transform.position.x-Player.transform.position.x>0)
			movement = new Vector2 (
				-speed.x,
				0);
		else
			movement = new Vector2 (
				speed.x,
				0);*/
		if (Input.GetKeyDown (KeyCode.A)) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
		}
		deplacement ();

	}
	
	void deplacement (){
		float moveX = -speed.x;
		float moveY = -speed.y;
		if (Player.transform.position.x + 10 > ennemi.transform.position.x) {
			moveX=speed.x;
		}
		if (Player.transform.position.y + 1 > ennemi.transform.position.y) {
			moveY=speed.y;
		}
		movement = new Vector2 (moveX, moveY);

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
				Destroy (col.gameObject);
			if (hp==0){
				Destroy (ennemi);
				Time.timeScale = 0;
			}
			
		}
	}
}