using UnityEngine;
using UnityEngine.UI;

public class GUIcontroller : MonoBehaviour {

	/*
	This class handles all GUI elements
	*/

	public Button pauseButton;
	private bool gameIsBeingPlayed = true;
	void Start () {
		//ini listeners
		pauseButton.onClick.AddListener(pauseGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void pauseGame() {
		if(gameIsBeingPlayed) {
			gameIsBeingPlayed = false;
			Time.timeScale = 0;
			pauseButton.GetComponentInChildren<Text>().text = "Play";
		}
		else {
			gameIsBeingPlayed = true;
			Time.timeScale = 1;
			pauseButton.GetComponentInChildren<Text>().text = "Pause";
		}
	}
}
