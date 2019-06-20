﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainSpawner : MonoBehaviour {
	
	public GameObject terrainToSpawn;
	public GameObject obstacleToSpawn;
	public Transform playerPosition;
	bool planeWasInstantiated = false;
	int timesInstantiated = 1;
	List<GameObject> terrain;
	void Start() {
		terrain = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("Postion of the player: " + playerPosition.position.z + " size:" + terrain.Count);
		if((playerPosition.position.z-25.6f) >= 70f*timesInstantiated & playerPosition.position.z != 29 & !planeWasInstantiated) {
			terrain.Add(Instantiate(terrainToSpawn, new Vector3(37.9f, 0f, 75.6f+(100*timesInstantiated)), Quaternion.Euler(0, 0, 0)));
			++timesInstantiated;
			planeWasInstantiated = true;
			createObstacles(terrain[terrain.Count-1]);
		}
		else if(playerPosition.position.z % 100  >= 1f) planeWasInstantiated = false;
	}

	public int getTerrainSize() {
		return terrain.Count;
	}

	public void deleteFirstElementTerrain() {
		if(terrain.Count > 0) {
			//Debug.Log(terrain.Count);
			Destroy(terrain[0]);
			terrain.RemoveAt(0);
		}
	}

	public float getTerrainPositionWithIndex(int position) {
		return terrain[position].transform.position.z;
	}

	private void createObstacles(GameObject newTerrain) {
		/*
		0 - 200 : 100 / 3
		200 - 500 : 100 / 4
		500 > 100 /5
		 */
		 if(playerPosition.position.z-29f >= 0 & playerPosition.position.z-29f <= 200) {
			 Debug.Log("if");
			 instantateObstacles(100/3, newTerrain);
		 }
		 else if(playerPosition.position.z-29f > 200 & playerPosition.position.z-29f <= 500) {
			 Debug.Log("else if");
			 instantateObstacles(100/4, newTerrain);
		 }
		 else {
			Debug.Log("else");
			 instantateObstacles(100/5, newTerrain);
		 }
	}

	private void instantateObstacles(int distanceBetweenObstacles, GameObject newTerrain) {
		float xPosition = newTerrain.transform.position.x;
		float yPosition = newTerrain.transform.position.y;
		float zPosition = newTerrain.transform.position.z;
		float zMin = newTerrain.transform.position.z-50f;
		float zMax = newTerrain.transform.position.z+50f;
		int i = 1;
		float zPositionOfAnObstacle = zMin;
		System.Random rnd = new System.Random();
		while(zPositionOfAnObstacle < zMax) {
			zPositionOfAnObstacle = zMin + (distanceBetweenObstacles*i);
			float x = rnd.Next(33, 42);
			Debug.Log("instantate obstacle");
			Instantiate(obstacleToSpawn, new Vector3(x, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
			++i;
		}
	}
}
