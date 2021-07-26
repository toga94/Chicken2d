using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDroppers : MonoBehaviour
{
    [Header("X - min, Y max")]
    public Vector2 spawnTime = new Vector2 (1,6);
    private float curtime;
    private float curSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        curSpawnTime = Random.Range(spawnTime.x, spawnTime.y);
    }

    void Spawn()
    {
        int randPos = (int)Random.Range(0,3);
        float xPos;
        if (randPos == 0)
        {
            xPos = -1.8f;
        }
        else if (randPos == 1)
        {
            xPos = 0;
        }
        else
        {
            xPos = 1.8f;
        }
        GameObject go = (GameObject) Instantiate(Resources.Load("BrickDrop"), new Vector2(xPos, Camera.main.transform.position.y + 5), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        if (curtime < curSpawnTime)
        {
            curtime += 1 * Time.deltaTime;
        }
        else
        {
            curtime = 0;
            curSpawnTime = Random.Range(spawnTime.x, spawnTime.y);
            Spawn();
        }
    }
}
