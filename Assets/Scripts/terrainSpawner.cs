using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainSpawner : MonoBehaviour {
	
	/*
	This class handles the creation of the terrain 
	*/
	public GameObject terrainToSpawn;
	public GameObject obstacleToSpawn;
	public GameObject smallObstacleToSpawn;
	public Transform playerPosition;
	bool planeWasInstantiated = false;
	float timesInstantiated = 1.0f;
	List<GameObject> terrain;
	List<GameObject> obstacles;
	static System.Random rnd = new System.Random();

	void Start() {
		terrain = new List<GameObject>();
		obstacles = new List<GameObject>();
		while(timesInstantiated < 7.0f) {
			terrain.Add(Instantiate(terrainToSpawn, new Vector3(37.9f, 0f, (float)(75.5f+(100.0f*timesInstantiated))), Quaternion.Euler(0, 0, 0)));
			createObstacles(terrain[terrain.Count-1]);
			++timesInstantiated;
		}
	}

	void Update () {
		if((playerPosition.position.z-25.6f) >= 70f*timesInstantiated & playerPosition.position.z != 29 & !planeWasInstantiated) {
			terrain.Add(Instantiate(terrainToSpawn, new Vector3(37.9f, 0f, (float)(75.5f+(100.0f*timesInstantiated))), Quaternion.Euler(0, 0, 0)));
			++timesInstantiated;
			planeWasInstantiated = true;
			createObstacles(terrain[terrain.Count-1]);
		}
		else if(playerPosition.position.z % 100  >= 1f) planeWasInstantiated = false;
	}

	/*
	Pre: True
	Post: Returns the size of the list that contains all the terrain pieces 
	*/
	public int getTerrainSize() {
		return terrain.Count;
	}

	/*
	Pre: True
	Post: Returns the size of the list that contains all the obstacles 
	*/
	public int getObstaclesSize() {
		return obstacles.Count;
	}

	/*
	Pre: True
	Post: Removes and destroys the first element of the terrain list
	*/
	public void deleteFirstElementTerrain() {
		if(terrain.Count > 0) {
			//Debug.Log(terrain.Count);
			Destroy(terrain[0]);
			terrain.RemoveAt(0);
		}
	}

	/*
	Pre: True
	Post: Removes and destroys all the obstacles that are no longer visible for the player
	*/
	public void deleteObstaclesNotVisibles() {
		for(int i = 0; i < obstacles.Count; ++i) {
			if(obstacles[i].transform.position.z < playerPosition.transform.position.z - 20f) {
				Destroy(obstacles[i]);
				obstacles.RemoveAt(i);
			}
		}
	}
 
	/*
	Pre: True
	Post: Returns z position of the first element of the gameobject list of terrains
	 */
	public float getTerrainPositionWithIndex(int position) {
		return terrain[position].transform.position.z;
	}

	/*
	Pre: True
	Post: It creates the obstacles based on the position of the terrain. The number of obstacles created is being done by the following formula:
		0 - 200 : 100 / 3
		200 - 500 : 100 / 4
		500 > 100 /5  
	*/
	private void createObstacles(GameObject newTerrain) {
		/*if(newTerrain.transform.position.z-29f >= 0 & newTerrain.transform.position.z-29f <= 200) {*/
			instantateObstacles(100/2, newTerrain);
		//}
		/*else if(newTerrain.transform.position.z-29f > 200  & playerPosition.position.z-29f <= 500) {
			instantateObstacles(100/4, newTerrain);
		}*/
		/*else {
			instantateObstacles(100/5, newTerrain);
		}*/
	}

	 IEnumerator MyMethod() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(0.5f);
		Debug.Log("After Waiting 2 Seconds");
 	}

	/*
	Pre: True
	Post: Instantate as many obstacles as possible on the newTerrain 
	*/
	private void instantateObstacles(int distanceBetweenObstacles, GameObject newTerrain) {
		float zMin = newTerrain.transform.position.z-50f;
		float zMax = newTerrain.transform.position.z+50f;
		/*System.Random rnd = new System.Random();
		float zPositionOfAnObstacle = zMin + (distanceBetweenObstacles);
		while(zPositionOfAnObstacle < zMax) {
			float x = rnd.Next(33, 42);
			GameObject obstacle = Instantiate(obstacleToSpawn, new Vector3(x, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
			obstacles.Add(obstacle);
			zPositionOfAnObstacle += distanceBetweenObstacles;
		}*/
		float zPositionOfAnObstacle = zMin + (distanceBetweenObstacles);
		while(zPositionOfAnObstacle < zMax) {
			for(int i = 0; i < 10000; ++i);
			int numberOfObstacles = rnd.Next(0,3);
			if(numberOfObstacles == 0) {
				StartCoroutine(MyMethod());
				float x = (float)rnd.NextDouble()+rnd.Next(33,42);
				GameObject obstacle = Instantiate(obstacleToSpawn, new Vector3(x, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
				obstacles.Add(obstacle);
			}
			else if(numberOfObstacles == 1) {
				for(int i = 0; i < 10000; ++i);
				StartCoroutine(MyMethod());
				float x = (float)rnd.NextDouble()+rnd.Next(33,42);
				GameObject obstacle = Instantiate(obstacleToSpawn, new Vector3(x, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
				obstacles.Add(obstacle);
				StartCoroutine(MyMethod());
				x = (float)rnd.NextDouble()+rnd.Next(33,42);
				obstacle = Instantiate(obstacleToSpawn, new Vector3(x, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
				obstacles.Add(obstacle);
			}
			else {
				GameObject obstacle = Instantiate(smallObstacleToSpawn, new Vector3(32.02f, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
				obstacles.Add(obstacle);
				obstacle = Instantiate(smallObstacleToSpawn, new Vector3(38.17f, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
				obstacles.Add(obstacle);
				obstacle = Instantiate(smallObstacleToSpawn, new Vector3(43.83f, 1.5f, zPositionOfAnObstacle), Quaternion.Euler(0, 0, 0));
				obstacles.Add(obstacle);
			}
			zPositionOfAnObstacle += distanceBetweenObstacles;
		}		
	}
}
