using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObstacleSpawnManager : MonoBehaviour
{
    public bool useRandomSeed;
    public int customSeed;
    public Transform obstacleContainer;
    public float spawnDelay = 3f;
    public float obstacleSpawnZOffset = 300f;
    public Obstacle[] obstacles;

    private float lastSpawnTime = Mathf.NegativeInfinity;
    private Transform playerTrans;
    private Vector3 playerStartPos;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    [System.Serializable]
    public struct Obstacle
    {
        public GameObject obstacleObj;
        public float spawnYOffset;
    }


    private void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
        playerStartPos = playerTrans.position;
        SetSeed();
    }

    private void Update()
    {
        GenerateObstacles();
    }

    private void GenerateObstacles()
    {
        if (lastSpawnTime + spawnDelay > Time.time)
        {
            return;
        }

        SpawnObstacle();

    }

    private void SpawnObstacle()
    {
        Obstacle obstacleToSpawn = PickRandomObstacle();
        Vector3 spawnPos = playerTrans.position + Vector3.forward * obstacleSpawnZOffset;
        Quaternion rot = Quaternion.LookRotation(Vector3.back, Vector2.up);
        spawnPos.y = obstacleToSpawn.spawnYOffset;
        Instantiate(obstacleToSpawn.obstacleObj, spawnPos, rot, obstacleContainer);
        lastSpawnTime = Time.time;
    }

    

    private Obstacle PickRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        return obstacles[randomIndex];
    }


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

        //For now, dont log seed in build mode
        if (Application.isEditor)
        {
            LogSeed(seed);
        }
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

}
