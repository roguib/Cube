using UnityEngine;

//extends MonoBehaivour
public class playerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float forwardForce = 1000f;
	public int middle = Screen.width/2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(rb.position.z);
		//rb.AddForce(0, 0, forwardForce*Time.deltaTime);
		if(rb.position.z > /*125f*/ 100000000f & rb.position.y >= 0) {
			this.enabled = false; //the end of the level
			rb.AddForce(0, 0, -(forwardForce*2)*Time.deltaTime, ForceMode.VelocityChange);
			FindObjectOfType<gameManager>().winnerGame();
		}
		else if(rb.position.y < -1f) {
			FindObjectOfType<gameManager>().endGame();
		}
		else {
			//rb.AddForce(0, 0, forwardForce*Time.deltaTime);
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
			else if(Input.GetKey("w")) {
				rb.AddForce(0, 0, 20*Time.deltaTime, ForceMode.VelocityChange);
			}
			//Another way to handle user input:
			//Debug.Log(Input.GetAxis("Horizontal") + Input.GetAxis("Vertical"));
		}
	}
}
