using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainSpawner : MonoBehaviour {
	
	public GameObject terrainToSpawn;
	public GameObject obstacleToSpawn;
	public Transform playerPosition;
	bool planeWasInstantiated = false;
	float timesInstantiated = 1.0f;
	List<GameObject> terrain;
	List<GameObject> obstacles;

	void Start() {
		terrain = new List<GameObject>();
		obstacles = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("Postion of the player: " + playerPosition.position.z + " size:" + terrain.Count);
		if((playerPosition.position.z-25.6f) >= 70f*timesInstantiated & playerPosition.position.z != 29 & !planeWasInstantiated) {
			terrain.Add(Instantiate(terrainToSpawn, new Vector3(37.9f, 0f, (float)(75.5f+(100.0f*timesInstantiated))), Quaternion.Euler(0, 0, 0)));
			++timesInstantiated;
			planeWasInstantiated = true;
			//createObstacles(terrain[terrain.Count-1]);
		}
		else if(playerPosition.position.z % 100  >= 1f) planeWasInstantiated = false;
	}

	public int getTerrainSize() {
		return terrain.Count;
	}

	public int getObstaclesSize() {
		return obstacles.Count;
	}

	public void deleteFirstElementTerrain() {
		if(terrain.Count > 0) {
			//Debug.Log(terrain.Count);
			Destroy(terrain[0]);
			terrain.RemoveAt(0);
		}
	}

	public void deleteObstaclesNotVisibles() {
		for(int i = 0; i < obstacles.Count; ++i) {
			if(obstacles[i].transform.position.z < playerPosition.transform.position.z - 20f) {
				Destroy(obstacles[i]);
				obstacles.RemoveAt(i);
			}
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
			//Debug.Log("if");
			//Debug.Log("player position: " + playerPosition.transform.position.x + " " + playerPosition.transform.position.y + " " + playerPosition.transform.position.z);
			instantateObstacles(100/3, newTerrain);
		}
		else if(playerPosition.position.z-29f > 200 & playerPosition.position.z-29f <= 500) {
			//Debug.Log("else if");
			//Debug.Log("player position: " + playerPosition.transform.position.x + " " + playerPosition.transform.position.y + " " + playerPosition.transform.position.z);
			instantateObstacles(100/4, newTerrain);
		}
		else {
			//Debug.Log("else");
			//Debug.Log("player position: " + playerPosition.transform.position.x + " " + playerPosition.transform.position.y + " " + playerPosition.transform.position.z);
			instantateObstacles(100/5, newTerrain);
		}
	}

	private void instantateObstacles(int distanceBetweenObstacles, GameObject newTerrain) {
		float xPosition = newTerrain.transform.position.x;
		float yPosition = newTerrain.transform.position.y;
		float zPosition = newTerrain.transform.position.z;
		float zMin = newTerrain.transform.position.z-50f;
		float zMax = newTerrain.transform.position.z+50f;
		System.Random rnd = new System.Random();
		float zPositionOfAnObstacle = zMin + (distanceBetweenObstacles);
		while(zPositionOfAnObstacle < zMax) {
			float x = rnd.Next(33, 42);
			//Debug.Log("instantate obstacle at position x: " + x + " y: " + 1.5f + " z: " + zPositionOfAnObstacle);
			GameObject obstacle = Instantiate(obstacleToSpawn, new Vector3(x, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
			obstacles.Add(obstacle);
			zPositionOfAnObstacle += distanceBetweenObstacles;
		}
	}
}
