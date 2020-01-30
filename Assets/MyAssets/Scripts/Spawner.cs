using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform playerTrans;
    public GameObject groundPrefab;
    public GameObject obstaclePrefab;
    public Transform groundContainer;
    public Transform obstacleContainer;
    public float groundLength = 100f;
    public float obstacleSpacing = 20f;
    public float viewDistance = 300f;
    public int groundCount = 10;
    public int obstacleCount = 100;
    public Transform[] lanes;

    private List<GameObject> activeGrounds = new List<GameObject>();
    private List<GameObject> activeObstacles = new List<GameObject>();

    private void Awake()
    {
        ClearLevel();
        GenerateLevel();
    }

    private void Update()
    {
        //Maybe only do this on some frames? every t seconds
        EntityCulling();
    }

    private void SpawnGround()
    {
        for (int i = 0; i < groundCount; i++)
        {
            GameObject newGround = Instantiate(groundPrefab, Vector3.forward * i * groundLength, Quaternion.identity, groundContainer);
            activeGrounds.Add(newGround);
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
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, obstacleContainer);
        activeObstacles.Add(newObstacle);
    }

    private void EntityCulling()
    {
        foreach (GameObject ground in activeGrounds)
        {
            float zPos = ground.transform.position.z;
            float deltaZToPlayer = Mathf.Abs(zPos - playerTrans.position.z);
            if (deltaZToPlayer > viewDistance)
            {
                ground.SetActive(false);
            }
            else
            {
                ground.SetActive(true);
            }
        }

        foreach (GameObject obstacle in activeObstacles)
        {
            float zPos = obstacle.transform.position.z;
            float deltaZToPlayer = Mathf.Abs(zPos - playerTrans.position.z);
            if (deltaZToPlayer > viewDistance)
            {
                obstacle.SetActive(false);
            }
            else
            {
                obstacle.SetActive(true);
            }
        }
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
