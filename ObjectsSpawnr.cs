using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawnr : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;
    // Start is called before the first frame update
  
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position,spawnObstaclePosition);
        if (distanceToHorizon < 120)
        {
            SpawnTriangle();
        } 
    }
    void SpawnTriangle()
    {
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 25);
        Instantiate(trianglePrefabs[(Random.Range(0, trianglePrefabs.Length))], spawnObstaclePosition, Quaternion.identity);
    }
} 






















