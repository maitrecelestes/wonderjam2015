using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController4 : MonoBehaviour {

	public Text ScoreText;
	private int score;
	GameObject Text;
	// Use this for initialization
	void Start () {
		Text = GameObject.Find ("Boss");
		score = 0;
		UpdateScore ();
		Text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 10) {
			StartCoroutine(Ending());
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
	IEnumerator Ending(){
		Text.SetActive (true);
		yield return new WaitForSeconds (4);
		Application.LoadLevel (8);
	}
}
