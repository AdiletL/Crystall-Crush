using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlace : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;
    public List<Chunk> spawnedChunks = new List<Chunk>();
    public GameObject EnemyD;
    private void Awake()
    {
         PlayerPrefs.SetInt("lvl", 0);
        PlayerPrefs.Save();

    }
    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
        SpawnChunk();
        SpawnChunk();
    }
    private void Update()
    {
        //if (ActiveStart.Yestrue == true)
        //{
        //    Destroy(spawnedChunks[0].gameObject);
        //    spawnedChunks.RemoveAt(0);
        //    EnemyD.SetActive(false);
        //    ActiveStart.Yestrue = false;
        //}
    }

    private void FixedUpdate()
    {
        if (Player.position.z > spawnedChunks[spawnedChunks.Count - 1].End.position.z - 50)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        if (PlayerPrefs.GetInt("lvl") > 2)
        {
            PlayerPrefs.SetInt("lvl", 0) ;
            PlayerPrefs.Save();
        }
       Chunk  newChunk = Instantiate(ChunkPrefabs[PlayerPrefs.GetInt("lvl")]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
        PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);
        PlayerPrefs.Save();
    }

}
