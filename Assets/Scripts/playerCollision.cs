using UnityEngine;

public class playerCollision : MonoBehaviour {
	
	public Rigidbody rb;
	public playerMovement playerMovement;
	//This function will be called every time an object collides with another
	void OnCollisionEnter(Collision collisionInformation) {
		//Debug.Log("We hit " + collisionInformation.collider.name);
		if(collisionInformation.collider.tag == "Obstacle") {
			Vector3 offset = new Vector3(0f, 0f, -500f);
			rb.AddForce(offset);
			//disable movement
			playerMovement.enabled = false;
			gameManager gameManager = FindObjectOfType<gameManager>();
			gameManager.endGame();
		}
	}
}
