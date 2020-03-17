using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public Transform playerTrans;
    public GameObject groundPrefab;
    public Transform groundContainer;
    public Transform obstacleContainer;
    public NavMeshSurface navSurface;
    public float groundLength = 100f;
    public float viewDistance = 300f;
    public float inspectorGenerateDistance = 1000f;

    private int initialGroundCount;
    private int nextGroundIndex;
    private Vector3 playerStartPos;
    private List<GameObject> spawnedGrounds = new List<GameObject>();


    private void Start()
    {
        playerStartPos = playerTrans.position;
        ClearLevel();
        InitSpawnGround(viewDistance);
    }

    private void Update()
    {
        //Maybe only do this on some frames? every t seconds
        EntityCulling();
        GenerateGrounds();
    }

    #region Init

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
