using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController3 : MonoBehaviour {

	public Text ScoreText;
	private int score;
	private GameObject wall;
	private GameObject text;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Heros");
		wall = GameObject.Find ("DesWall");
		text = GameObject.Find ("TextBoss");
		text.SetActive (false);
		score = 0;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 9) {
			wall.SetActive (false);
		} else if (score < 9 && (player.transform.position.x >= 155 && player.transform.position.x <= 160)) {
			text.SetActive (true);
		} else {
			text.SetActive (false);
		}
		
	}
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore()
	{
		ScoreText.text = "Score: " + score;
	}
}

