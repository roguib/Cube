using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainSpawner : MonoBehaviour {
	
	public GameObject terrainToSpawn;
	public Transform playerPosition;
	bool planeWasInstantiated = false;
	int timesInstantiated = 1;

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		Debug.Log("Postion of the player: " + playerPosition.position.z);
		if((playerPosition.position.z-25.6f) >= 70f*timesInstantiated & playerPosition.position.z != 29 & !planeWasInstantiated) {
			++timesInstantiated;
			Instantiate(terrainToSpawn, new Vector3(37.9f, 0f, 75.6f*timesInstantiated), Quaternion.Euler(0, 0, 0));
			planeWasInstantiated = true;
		}
		else if(playerPosition.position.z % 100  >= 1f) planeWasInstantiated = false;
	}
}
