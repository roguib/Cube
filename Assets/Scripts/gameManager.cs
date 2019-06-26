using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public void Start() {
		//SceneManager.LoadScene("menuScene");
	}

	/*
	This class handles the restart of the game
	*/
	bool isGameOver = false;
	public float restartDelay = 2f;

	/*
	Pre: True
	Post: The game is restarted and the player returns to his initial position
	*/
	public void endGame() {
		if(!isGameOver) {
			isGameOver = true;
			Invoke("restartGame", restartDelay);
		}
	}

	/*
	Pre: True
	Post: Game engine loads again the one an only scene of the game to restart it
	*/
	private void restartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	/*
	Pre: True
	Post: Return the value of isGameOver attribute
	*/
	public bool getIsGameOver() {
		return this.isGameOver;
	}
}
