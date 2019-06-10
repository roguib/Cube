using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public Transform playerTransform;
	public Rigidbody rigidbody;
	public Text scoreText;
	private int previousPosition;
	
	// Update is called once per frame
	void Update () {
		//We update the score only if the object is going forward. 
		//In case the object has collided, we don't want to reduce the score of the player
		if(transform.InverseTransformDirection(rigidbody.velocity).z > 0.0001f & !FindObjectOfType<gameManager>().getIsGameOver()) scoreText.text = (playerTransform.position.z-29).ToString("0");
	}
}
