using UnityEngine;

public class terrainDestroyer : MonoBehaviour {
	
	/*
	This class handles the destruction of the terrain that no longer is visible for the player 
	*/
	public Transform playerPosition;
	
	void Update () {
		terrainSpawner terrainSpawner = FindObjectOfType<terrainSpawner>();
		if(terrainSpawner.getTerrainSize() > 2) {
			if((playerPosition.transform.position.z-49.0f) > (terrainSpawner.getTerrainPositionWithIndex(0)-75.0f) + 100.0f) {
				terrainSpawner.deleteFirstElementTerrain(); 
			}
		}
		if(terrainSpawner.getObstaclesSize() > 5) {
			terrainSpawner.deleteObstaclesNotVisibles();
		}
	}
}
