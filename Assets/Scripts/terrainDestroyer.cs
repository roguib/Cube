using UnityEngine;

public class terrainDestroyer : MonoBehaviour {

	public Transform playerPosition;
	
	// Update is called once per frame
	void Update () {
		terrainSpawner terrainSpawner = FindObjectOfType<terrainSpawner>();
		//Debug.Log((playerPosition.transform.position.z-29.0f) + 50f + " " + (terrainSpawner.getTerrainPositionWithIndex(0)-75.6f));
		if(terrainSpawner.getTerrainSize() > 2) {
			if((playerPosition.transform.position.z-49.0f) > (terrainSpawner.getTerrainPositionWithIndex(0)-75.0f) + 100.0f) {
				terrainSpawner.deleteFirstElementTerrain(); 
				//Debug.Log("I want to destroy it " + playerPosition.transform.position.z + " " + playerPosition.transform.position.z); 
			}
		}
		//Debug.Log(terrainSpawner.getObstaclesSize());
		if(terrainSpawner.getObstaclesSize() > 5) {
			//Debug.Log("I want to destroy it " + playerPosition.transform.position.z + " " + playerPosition.transform.position.z); 
			terrainSpawner.deleteObstaclesNotVisibles();
		}
	}
}
