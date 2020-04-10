using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public GameObject terrainPrefab;
    public GameObject groundPrefab;
    public Transform groundContainer;
    public Transform obstacleContainer;
    public NavMeshSurface navSurface;
    public float terrainLength = 1000f;
    public float groundLength = 100f;
    public float terrainViewDistance = 2000f;
    public float groundViewDistance = 300f;
    public float inspectorGenerateDistance = 1000f;

    private int initialGroundCount;
    private int initialTerrainCount;
    private int nextTerrainIndex;
    private int nextGroundIndex;
    private Transform playerTrans;
    private Vector3 playerStartPos;
    private List<GameObject> spawnedGrounds = new List<GameObject>();
    private List<GameObject> spawnedTerrains = new List<GameObject>();
    private List<GameObject> obstacles = new List<GameObject>();


    private void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
        playerStartPos = playerTrans.position;
        InitObstacles();
        ClearLevel();
        InitSpawnGround(groundViewDistance);
        InitSpawnTerrain(terrainViewDistance);
    }

    private void Update()
    {
        //Maybe only do this on some frames? every t seconds
        GroundCulling();
        ObstacleCulling();
        GenerateGrounds();
        GenerateTerrains();
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

    private void InitSpawnTerrain(float distance)
    {
        initialTerrainCount = (int)(distance / terrainLength);
        for (int i = 0; i < initialTerrainCount; i++)
        {
            float zPos = playerStartPos.z + i * terrainLength;
            SpawnTerrain(zPos);
        }
        nextTerrainIndex = initialTerrainCount;
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

    private void GenerateTerrains()
    {
        float distanceToNextSpawn = terrainLength * (nextTerrainIndex - initialTerrainCount);
        if (playerTrans.position.z - playerStartPos.z > distanceToNextSpawn)
        {
            SpawnTerrain(playerStartPos.z + nextTerrainIndex * terrainLength);
            nextTerrainIndex++;
        }
    }

    private void SpawnGround(float zDistance)
    {
        Vector3 spawnPosition = Vector3.forward * zDistance;
        GameObject newGround = Instantiate(groundPrefab, spawnPosition, Quaternion.identity, groundContainer);
        spawnedGrounds.Add(newGround);
        navSurface.BuildNavMesh();
    }

    private void SpawnTerrain(float zDistance)
    {
        Vector3 spawnPosition = Vector3.forward * zDistance;
        GameObject newTerrain = Instantiate(terrainPrefab, spawnPosition, Quaternion.identity, groundContainer);
        spawnedTerrains.Add(newTerrain);
    }

    //Enable grounds view dist from player and disable otherwise
    private void GroundCulling()
    {
        foreach (var ground in spawnedGrounds)
        {
            float zPos = ground.transform.position.z;
            float deltaZToPlayer = Mathf.Abs(zPos - playerTrans.position.z);
            if (deltaZToPlayer > groundViewDistance)
            {
                ground.SetActive(false);
            }
            else
            {
                ground.SetActive(true);
            }
        }
    }

    private void TerrainCulling()
    {
        foreach (var terrain in spawnedTerrains)
        {
            float zPos = terrain.transform.position.z;
            float deltaZToPlayer = Mathf.Abs(zPos - playerTrans.position.z);
            if (deltaZToPlayer > terrainViewDistance)
            {
                terrain.SetActive(false);
            }
            else
            {
                terrain.SetActive(true);
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
            if (deltaZToPlayer > groundViewDistance)
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
        InitSpawnTerrain(terrainViewDistance);
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
