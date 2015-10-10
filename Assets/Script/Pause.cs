using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private GameObject PauseCanvas; 
	void Start () {
		PauseCanvas = GameObject.Find ("PauseCanvas");
	}
	
	public void Resume () {
		PauseCanvas.SetActive (false);
		Time.timeScale = 1;
	}
	public void LoadScene(int level)
	{
		Time.timeScale = 1;
		Application.LoadLevel (level);
	}
}
