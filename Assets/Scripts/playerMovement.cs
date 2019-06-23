using UnityEngine;

//extends MonoBehaivour
public class playerMovement : MonoBehaviour {

/*
This class handles player movement
*/
	public Rigidbody rb;
	public int forwardForce = 7000;
	public int middle = Screen.width/2;
	
	void FixedUpdate () {
		rb.transform.rotation = Quaternion.Euler(0, 0, 0);
		rb.AddForce(0, 0, 750*Time.deltaTime);
		if(rb.position.y < -1f) {
			FindObjectOfType<gameManager>().endGame(); //we are falling of the road
		}
		else {
			//for mobile devices:
			if(Input.touchCount > 0) {
				Touch touch = Input.GetTouch(0);
				//Debug.Log(touch.position.x + " " + touch.position.y);
				if(touch.position.x <= middle) {
					rb.AddForce(-30*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
				}
				else if(touch.position.x > middle) {
					rb.AddForce(30*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
				}
			}
			if(Input.GetKey("d")) {
				rb.AddForce(25*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			}
			else if(Input.GetKey("a")) {
				rb.AddForce(-25*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			}
			//Another way to handle user input:
			//Debug.Log(Input.GetAxis("Horizontal") + Input.GetAxis("Vertical"));
		}
	}
}