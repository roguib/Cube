using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GUIcontroller : MonoBehaviour {

	/*
	This class handles all GUI elements
	*/

	public Button pauseButton;
	public Button playButton;
	public Button quitButton;
	private bool gameIsBeingPlayed = true;
	public GameObject pauseMenu;
	void Start () {
		//ini listeners
		pauseButton.onClick.AddListener(pauseGame);
		playButton.onClick.AddListener(pauseGame);
		quitButton.onClick.AddListener(quitGame);
		pauseMenu.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void pauseGame() {
		if(gameIsBeingPlayed) {
			gameIsBeingPlayed = false;
			Time.timeScale = 0;
			pauseMenu.SetActive(true);
			pauseButton.gameObject.SetActive(false);
		}
		else {
			gameIsBeingPlayed = true;
			Time.timeScale = 1;
			pauseMenu.SetActive(false);
			pauseButton.gameObject.SetActive(true);
		}
	}

	private void quitGame() {
		SceneManager.LoadScene("menuScene");	
	}
}
