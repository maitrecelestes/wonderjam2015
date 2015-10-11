using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController5 : MonoBehaviour {

	public Text ScoreText;
	private int score;
	private float spawnWait=2;
	public float startWait;
	public int hazardCount;
	public float waveWait;
	private Vector2 spawnValues;
	public GameObject hazard;
	private GameObject Textinfo;
	private GameObject Textvictoire;
	private GameObject Player;
	private int j=0;
	// Use this for initialization
	void Start () {
		
		score = 0;
		Textinfo = GameObject.Find ("Info");
		Textvictoire = GameObject.Find ("victoire");
		Textvictoire.SetActive (false);
		Player = GameObject.Find ("Heros");
		UpdateScore ();
		StartCoroutine( SpawnWaves ());
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		Textinfo.SetActive (false);
		while (true) {
			for (int i=0; i<hazardCount; i++) {
				if(score==20)
				{
					Textvictoire.SetActive (true);
					yield return new WaitForSeconds (4);
					Application.LoadLevel (4);
					break;
				}
				j++;
				if(j>12)
				{
					
					Vector2 spawnPosition2 = new Vector2 (Player.transform.position.x-20,0);
					Instantiate (hazard, spawnPosition2,Quaternion.identity);
				}
				Vector2 spawnPosition = new Vector2 (Player.transform.position.x+20,0);
				Instantiate (hazard, spawnPosition,Quaternion.identity);
				
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
	void Update () {
		
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

