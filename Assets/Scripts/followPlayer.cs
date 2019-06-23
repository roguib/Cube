using UnityEngine;

public class followPlayer : MonoBehaviour {

	/*
	This class handles the camera movement by taking into an account the position of the player (cube) by adding
	an offset to the position of the camera so it follow the desired object as it moves through the road */

	public Transform transformPlayer;
	public Vector3 offset = new Vector3(0, 4.26f, -20.0f);
	// Set camera position behind the position of an object and update it every frame
	void Update () {
		//because the script is inside the camera, the transform.position refers to the transfrom of the camera
		transform.position = transformPlayer.position + offset; //camera transfrom equals the position of the object
	}
}