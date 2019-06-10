using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	bool isGameOver = false;
	public float restartDelay = 2f;

	public void endGame() {
		if(!isGameOver) {
			Debug.Log("Game Over");
			isGameOver = true;
			Invoke("restartGame", restartDelay);
		}
	}

	public void winnerGame() {
		Debug.Log("Winner!");
	}

	public void restartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public bool getIsGameOver() {
		return this.isGameOver;
	}
}
