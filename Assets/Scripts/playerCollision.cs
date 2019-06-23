using UnityEngine;

public class playerCollision : MonoBehaviour {

	/*
	This class is responsible for handling the collision.
	OnCollisionEnter goes after FixedUpdate on unity execution order so maybe
	some collisions will be undetected. To fix this we can try to build our
	collision system but for now will work with that way
	*/

	public Rigidbody rb;
	public playerMovement playerMovement;
	/*
	Pre: A collision has ocurred
	Post: If the collision has happened with an obstacle, this fuction applys a force against the player movement
	to create a better sense of impact
	*/
	void OnCollisionEnter(Collision collisionInformation) {
		//Debug.Log("We hit " + collisionInformation.collider.name);
		if(collisionInformation.collider.tag == "Obstacle") {
			Vector3 offset = new Vector3(0f, 0f, -500f);
			rb.AddForce(offset);
			playerMovement.enabled = false; //disable movement
			gameManager gameManager = FindObjectOfType<gameManager>();
			gameManager.endGame();
		}
	}
}
