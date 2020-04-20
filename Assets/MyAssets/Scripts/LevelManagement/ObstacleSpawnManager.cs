﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class ObstacleSpawnManager : MonoBehaviour
{
    public bool useRandomSeed;
    public int customSeed;
    public Transform obstacleContainer;
    public float startCreditRate = 1f;
    public float creditTimeFactor = .05f;
    public float spawnDelay = 3f;
    public float spawnAreaWidth = 20f;
    public Obstacle[] obstacles;

    private float currentCredits = 0f;
    private float currentCreditRate;
    private float lastSpawnTime = Mathf.NegativeInfinity;
    private Transform playerTrans;
    private Vector3 playerStartPos;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    [System.Serializable]
    public struct Obstacle
    {
        public GameObject obstacleObj;
        public float spawnYOffset;
        public float minZOffset;
        public float maxZOffset;
        public float cost;
    }

    private void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
        playerStartPos = playerTrans.position;
        currentCreditRate = startCreditRate;
        SortObstalcesByCost();
        SetSeed();
    }

    private void Update()
    {
        GenerateObstacles();
        currentCredits += currentCreditRate * Time.deltaTime;
        currentCreditRate += Time.deltaTime * creditTimeFactor;
    }

    private void SortObstalcesByCost()
    {
        obstacles = obstacles.OrderByDescending(o => o.cost).ToArray<Obstacle>();
    }

    private void GenerateObstacles()
    {
        if (lastSpawnTime + spawnDelay > Time.time)
        {
            return;
        }

        SpawnMostExpensiveObstacle();

    }

    private void SpawnMostExpensiveObstacle()
    {
        //Assumes sorted by descending
        foreach (var obstacle in obstacles)
        {
            if (currentCredits >= obstacle.cost)
            {
                SpawnObstacle(obstacle);
                currentCredits -= obstacle.cost;
            }
        }
    }

    private void SpawnObstacle(Obstacle obstacle)
    {
        Quaternion rot = Quaternion.LookRotation(Vector3.back, Vector2.up);
        float zOffset = Random.Range(obstacle.minZOffset, obstacle.maxZOffset);
        Vector3 spawnPos;
        spawnPos.x = Random.Range(-spawnAreaWidth, spawnAreaWidth);
        spawnPos.y = obstacle.spawnYOffset;
        spawnPos.z = playerTrans.position.z + zOffset;
        Instantiate(obstacle.obstacleObj, spawnPos, rot, obstacleContainer);
        lastSpawnTime = Time.time;
    }

    

    private Obstacle PickRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        return obstacles[randomIndex];
    }

    private void OnGUI()
    {
        GUI.TextField(new Rect(10, 10, 200, 20),"Current Credits: " + (int) currentCredits);
        GUI.TextField(new Rect(10, 40, 200, 20), "Credits/Second: " + (int) currentCreditRate);
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
