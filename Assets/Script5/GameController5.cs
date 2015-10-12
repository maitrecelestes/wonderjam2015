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
	public GameObject hazard2;
	private GameObject Textinfo;
	private GameObject Textvictoire;
	private GameObject Text2;
	private GameObject Text3;
	private GameObject Player;
	private int j=0;


	// Use this for initialization
	void Start () {
		
		score = 0;
		Textinfo = GameObject.Find ("Info");
		Textvictoire = GameObject.Find ("victoire");
		Text2 = GameObject.Find ("Info2");
		Text2.SetActive (false);
		Text3 = GameObject.Find ("Info3");
		Text3.SetActive (false);
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
				if(score>=10)
				{
					if(j==8)
					{
						Text2.SetActive (true);
						yield return new WaitForSeconds (startWait);
						Text2.SetActive (false);
					}

					if(j<=12 && score>=12)
					{
						j++;
						Vector2 spawnPosition3 = new Vector2 (Player.transform.position.x-20,0);
						Instantiate (hazard2, spawnPosition3,Quaternion.identity);
						yield return new WaitForSeconds (1);
						Vector2 spawnPosition4 = new Vector2 (Player.transform.position.x+20,0);
						Instantiate (hazard2, spawnPosition4,Quaternion.identity);
					}
					if(j>=13 && score>=21)
					{
						if(j==13)
						{
							Text3.SetActive (true);
							yield return new WaitForSeconds (startWait);
							Text3.SetActive (false);
						}
						if(j<=17 && score>=23)
						{
							j++;
							Vector2 spawnPosition5 = new Vector2 (Player.transform.position.x-20,0);
							Instantiate (hazard2, spawnPosition5,Quaternion.identity);
							Vector2 spawnPosition6 = new Vector2 (Player.transform.position.x+20,0);
							Instantiate (hazard, spawnPosition6,Quaternion.identity);
						}
						if(j>=18 && score >= 31)
						{
						Textvictoire.SetActive (true);
						yield return new WaitForSeconds (4);
						Application.LoadLevel (10);
						}
					}
				}
				
				if(score<10 && j<=7)
				{
					j++;
					Vector2 spawnPosition = new Vector2 (Player.transform.position.x+20,0);
					Instantiate (hazard, spawnPosition,Quaternion.identity);
				}
				if(j>4 && j<=7)
				{
					
					Vector2 spawnPosition2 = new Vector2 (Player.transform.position.x-20,0);
					Instantiate (hazard, spawnPosition2,Quaternion.identity);
				}
				
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

