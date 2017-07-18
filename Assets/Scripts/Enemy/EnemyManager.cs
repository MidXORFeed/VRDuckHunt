using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;

    public int enemyMaxCount = 10;
    public static int enemyCount;

    public float spawnTime = 3f;

    void Start()
    {
        enemyCount = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        Quaternion spawnRandomRotation = Random.rotation;

        if (enemyCount != enemyMaxCount)
        {
            enemyCount += 1;

            Instantiate(enemy, spawnPoint.position, spawnRandomRotation);
        }

    }

}
