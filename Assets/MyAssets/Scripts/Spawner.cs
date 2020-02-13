using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class Spawner : MonoBehaviour
{
    public bool useRandomSeed;
    public int customSeed;
    public Transform playerTrans;
    public GameObject groundPrefab;
    public Transform groundContainer;
    public Transform obstacleContainer;
    public NavMeshSurface navSurface;
    public float groundLength = 100f;
    public float obstacleSpacing = 20f;
    public float obstacleSafeZone = 100f;
    public float viewDistance = 300f;
    public Obstacle[] obstacles;
    public Transform[] lanes;

    private int initialGroundCount;
    private int initialObstacleCount;
    private int nextGroundIndex;
    private int nextObstacleIndex;
    private Vector3 playerStartPos;
    private List<GameObject> spawnedGrounds = new List<GameObject>();
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    [System.Serializable]
    public struct Obstacle
    {
        public GameObject obstacleObj;
        public Vector3 spawnOffset;
    }


    private void Start()
    {
        playerStartPos = playerTrans.position;
        ClearLevel();
        InitLevel();
    }

    private void Update()
    {
        //Maybe only do this on some frames? every t seconds
        EntityCulling();
        GenerateGrounds();
        GenerateObstacles();
    }

    #region Init

    //Spawn first chunks of grounds within view distance
    private void InitSpawnGround()
    {
        initialGroundCount = (int) (viewDistance / groundLength);
        for (int i = 0; i < initialGroundCount; i++)
        {
            float zPos = playerStartPos.z + i * groundLength;
            SpawnGround(zPos);
        }
        nextGroundIndex = initialGroundCount;
    }

    //Spawn first chunks of obstacles within view distance
    private void InitSpawnObstacles()
    {
        initialObstacleCount = (int)(viewDistance / obstacleSpacing);
        for (int i = 0; i < initialObstacleCount; i++)
        {
            float zPos = playerStartPos.z + i * obstacleSpacing;
            if (zPos > obstacleSafeZone)
            {
                SpawnObstacle(zPos);
            }
        }
        nextObstacleIndex = initialObstacleCount;
    }

    #endregion

    #region Generation
    //Everytime player moves groundLength in Z, generate another ground
    private void GenerateGrounds ()
    {
        float distanceToNextSpawn = groundLength * (nextGroundIndex - initialGroundCount);
        if (playerTrans.position.z - playerStartPos.z > distanceToNextSpawn)
        {
            SpawnGround(playerStartPos.z + nextGroundIndex * groundLength);
            nextGroundIndex++;
        }
    }

    //Everytime player moves obstacle spacing in z, gen another obstacle.
    private void GenerateObstacles()
    {
        float distanceToNextSpawn = obstacleSpacing * (nextObstacleIndex - initialObstacleCount);
        if (playerTrans.position.z - playerStartPos.z > distanceToNextSpawn)
        {
            SpawnObstacle(playerStartPos.z + nextObstacleIndex * obstacleSpacing);
            nextObstacleIndex++;
        }
    }

    private void SpawnGround(float zDistance)
    {
        Vector3 spawnPosition = Vector3.forward * zDistance;
        GameObject newGround = Instantiate(groundPrefab, spawnPosition, Quaternion.identity, groundContainer);
        spawnedGrounds.Add(newGround);
        navSurface.BuildNavMesh();
    }

    private void SpawnObstacle(float zDistance)
    {
        Vector3 lanePosition = PickRandomLane().position;
        Vector3 spawnPosition = new Vector3(lanePosition.x, lanePosition.y, zDistance);
        Obstacle tempObstacle = PickRandomObstacle();
        spawnPosition += tempObstacle.spawnOffset;
        GameObject newObstacle = Instantiate(tempObstacle.obstacleObj, spawnPosition, Quaternion.LookRotation(Vector3.back, Vector3.up), obstacleContainer);
        spawnedObstacles.Add(newObstacle);
    }

    //Enable stuff ahead and disable stuff behind view dist
    private void EntityCulling()
    {
        foreach (GameObject ground in spawnedGrounds)
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

        foreach (GameObject obstacle in spawnedObstacles)
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

    #region Helpers

    private Obstacle PickRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        return obstacles[randomIndex];
    }

    private Transform PickRandomLane()
    {
        int randomIndex = Random.Range(0, lanes.Length);
        return lanes[randomIndex];
    }

    #endregion

    #region Seed

    private void SetSeed()
    {
        int seed;
        if (useRandomSeed)
        {
            seed = System.DateTime.Now.Millisecond;
        }
        else
        {
            seed = customSeed;
        }

        Random.InitState(seed);
        LogSeed(seed);
    }

    private void LogSeed(int seed)
    {
        string path = Application.dataPath + "/Seeds_Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Procedural Generation Seed Log\n\nCreated: " + System.DateTime.Now + "\n\n\n");
        }

        string mode = Application.isPlaying ? "Play mode" : "Editor Mode";
        string content = System.DateTime.Now + " || " + mode + " || Seed: " + seed + "\n";
        File.AppendAllText(path, content);
    }

    #endregion

    #region Public Functions

    public void InitLevel()
    {
        SetSeed();
        InitSpawnGround();
        InitSpawnObstacles();
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

        #endregion

    }


}
