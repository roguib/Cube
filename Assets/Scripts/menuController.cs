using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {

	public Button newGameButton;
	public Button rankingButton;
	public GameObject message;
	// Use this for initialization
	void Start () {
		newGameButton.onClick.AddListener(newGame);
		rankingButton.onClick.AddListener(loadRanking);
		message.SetActive(false);
	}

	void Update () {
		
	}

	public void newGame() {
		Debug.Log("load game");
		SceneManager.LoadScene("level01Scene");
	}

	public void loadRanking() {
		message.SetActive(true);
	}
	
}
