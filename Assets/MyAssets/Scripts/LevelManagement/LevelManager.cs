using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform groundContainer;
    public Transform obstacleContainer;
    public NavMeshSurface navSurface;
    public float groundLength = 100f;
    public float viewDistance = 300f;
    public float inspectorGenerateDistance = 1000f;

    private int initialGroundCount;
    private int nextGroundIndex;
    private Transform playerTrans;
    private Vector3 playerStartPos;
    private List<GameObject> spawnedGrounds = new List<GameObject>();
    private List<GameObject> obstacles = new List<GameObject>();


    private void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
        playerStartPos = playerTrans.position;
        InitObstacles();
        ClearLevel();
        InitSpawnGround(viewDistance);
    }

    private void Update()
    {
        //Maybe only do this on some frames? every t seconds
        GroundCulling();
        ObstacleCulling();
        GenerateGrounds();
    }

    #region Init
    
    //Assumes the hierarchy is obstacle container, then one more level of containers
    private void InitObstacles()
    {
        foreach (Transform childContainer in obstacleContainer)
        {
            foreach (Transform obstacle in childContainer)
            {
                obstacles.Add(obstacle.gameObject);
                obstacle.gameObject.SetActive(false);
            }
            
        }
    }

    //Spawn first chunks of grounds within distance
    private void InitSpawnGround(float distance)
    {
        initialGroundCount = (int)(distance / groundLength);
        for (int i = 0; i < initialGroundCount; i++)
        {
            float zPos = playerStartPos.z + i * groundLength;
            SpawnGround(zPos);
        }
        nextGroundIndex = initialGroundCount;
    }

    #endregion

    #region Generation
    //Everytime player moves groundLength in Z, generate another ground
    private void GenerateGrounds()
    {
        float distanceToNextSpawn = groundLength * (nextGroundIndex - initialGroundCount);
        if (playerTrans.position.z - playerStartPos.z > distanceToNextSpawn)
        {
            SpawnGround(playerStartPos.z + nextGroundIndex * groundLength);
            nextGroundIndex++;
        }
    }

    private void SpawnGround(float zDistance)
    {
        Vector3 spawnPosition = Vector3.forward * zDistance;
        GameObject newGround = Instantiate(groundPrefab, spawnPosition, Quaternion.identity, groundContainer);
        spawnedGrounds.Add(newGround);
        navSurface.BuildNavMesh();
    }

    //Enable grounds view dist from player and disable otherwise
    private void GroundCulling()
    {
        foreach (var ground in spawnedGrounds)
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
    }

    //Enable obstacles view dist from player and disable otherwise
    private void ObstacleCulling()
    {
        foreach (var obstacle in obstacles)
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

    #endregion

    #region Public Functions

    //For use in inspector to generate ground
    public void GenerateLevelInspector()
    {
        InitSpawnGround(inspectorGenerateDistance);
    }

    public void ClearLevel()
    {
        GameObject[] grounds = new GameObject[groundContainer.childCount];
        int i = 0;

        foreach (Transform child in groundContainer)
        {
            grounds[i] = child.gameObject;
            i++;
        }

        foreach (GameObject ground in grounds)
        {
            DestroyImmediate(ground);
        }

        #endregion
    }
}
