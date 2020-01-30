using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform playerTrans;
    public GameObject groundPrefab;
    public Transform groundContainer;
    public float groundLength = 100f;
    public int groundCount = 10;
    public GameObject obstaclePrefab;
    public Transform obstacleContainer;
    public float obstacleSpacing = 20f;
    public int obstacleCount = 100;
    public Transform[] lanes;

    private void Awake()
    {
        ClearLevel();
        GenerateLevel();
    }

    private void SpawnGround()
    {
        for (int i = 0; i < groundCount; i++)
        {
            Instantiate(groundPrefab, Vector3.forward * i * groundLength, Quaternion.identity, groundContainer);
        }
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            SpawnObstacle(i * obstacleSpacing);
        }
    }

    private void SpawnObstacle(float zDistance)
    {
        Vector3 lanePosition = PickRandomLane().position;
        Vector3 spawnPosition = new Vector3(lanePosition.x, lanePosition.y, zDistance);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, obstacleContainer);
    }

    private Transform PickRandomLane()
    {
        int randomIndex = Random.Range(0, lanes.Length);
        return lanes[randomIndex];
    }

    public void GenerateLevel()
    {
        SpawnGround();
        SpawnObstacles();
    }

    public void ClearLevel()
    {
        GameObject[] grounds = new GameObject[groundContainer.childCount];
        GameObject[] obstacles = new GameObject[obstacleContainer.childCount];
        int i = 0;
        int j = 0;

        foreach (Transform child in groundContainer)
        {
            grounds[i] = child.gameObject;
            i++;
        }
        foreach (Transform child in obstacleContainer)
        {
            obstacles[j] = child.gameObject;
            j++;
        }

        foreach (GameObject ground in grounds)
        {
            DestroyImmediate(ground);
        }

        foreach (GameObject obstacle in obstacles)
        {
            DestroyImmediate(obstacle);
        }
    }


}
