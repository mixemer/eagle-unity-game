using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public Balloon[] balloons;

    public int maxCount = 2;
    public int currentCount = 0;

    bool isSpawing = false;
    // Update is called once per frame
    void Update()
    {
        if (currentCount >= maxCount) return;
        if (isSpawing) return;

        isSpawing = true;
        Invoke("Spawn", 1f);
    }

    void Spawn()
    {
        int randomIndexSpawn = Random.Range(0, SpawnPoints.Length);
        GameObject spawnPoint = SpawnPoints[randomIndexSpawn];

        int randomIndexBalloon = Random.Range(0, balloons.Length);
        Balloon randomBalloon = balloons[randomIndexBalloon];

        Instantiate(randomBalloon.gameObject, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), Quaternion.identity);
        currentCount++;

        isSpawing = false;
    }
}
