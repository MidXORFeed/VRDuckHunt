using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Transform player;
    float positionY;
    public float floatStrength = 10f;
    public float targetYOffset = 10f;

    void Start()
    {
        transform.position = player.position;
        positionY = transform.position.y + targetYOffset;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, positionY + (Mathf.Sin(Time.time) * floatStrength), player.position.z);
    }
}
