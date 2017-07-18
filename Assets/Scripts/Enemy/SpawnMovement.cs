using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    public Transform player;
    public float spawnYOffset = 25f;
    public float spawnZOffset = -25f;

    void Start()
    {
        transform.position = player.position;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + spawnYOffset, player.position.z + spawnZOffset);
    }
}
