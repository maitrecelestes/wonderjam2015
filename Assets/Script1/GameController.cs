using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text ScoreText;
	private int score;
	// Use this for initialization
	void Start () {
		
		score = 0;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		//UpdateScore ();
	}
	void UpdateScore()
	{
		//ScoreText.text = "Score: " + score;
	}
}
