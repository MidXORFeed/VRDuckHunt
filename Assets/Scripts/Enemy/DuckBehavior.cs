using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehavior : MonoBehaviour
{
    public event Action DeathEvent;
    public float maxHealth;
    public float currentHealth;

    public Transform targetPlayer;
    public Transform exit;
    public float enemyMaxLifeTime = 30f;
    public float enemyLifeTime = 0;
    public float movementSpeed = 10f;
    public float rotationDamping = 1f;
    public float raycastOffset = 1f;
    public float raycastDistance = 10f;
    public float raycastDamping = 100f;

    private Transform target;
    private DuckState currentState;

    private enum DuckState
    {
        Flying,
        Falling,
        Sinking,
        Dead
    }

    public void DeathAction()
    {
        if (DeathEvent != null)
        {
            DeathEvent();
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentState = DuckState.Flying;
    }

    void Update()
    {
        Target();
        Pathfinding();
        Move();
    }

    void OnCollisionEnter(Collision collision)
    {
        // May have to write a new collision method for detecting bullets which
        // involves drawing a line between the bullet from the previous frame 
        // and current frame and check if the line intersects the duck
        if (collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>() != null)
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().attackDamage);
        }
    }

    void TakeDamage(float damageValue)
    {
        if ((currentHealth -= damageValue) <= 0.0f)
        {
            currentHealth = 0.0f;
            currentState = DuckState.Falling;
            DeathAction();
        }
    }

    void Target()
    {
        enemyLifeTime += Time.deltaTime;
        if (enemyLifeTime >= enemyMaxLifeTime)
        {
            target = exit;
        }
        else
        {
            target = targetPlayer;
        }
    }

    void Turn()
    {
        Vector3 position = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamping * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding()
    {
        RaycastHit hit;
        Vector3 raycastVectorOffset = Vector3.zero;

        // Raycast Vectors
        Vector3 right = transform.position + transform.right * raycastOffset;
        Vector3 left = transform.position - transform.right * raycastOffset;
        Vector3 up = transform.position + transform.up * raycastOffset;
        Vector3 down = transform.position - transform.up * raycastOffset;

        // Raycast Visuals
        Debug.DrawRay(right, transform.forward * raycastDistance, Color.white);
        Debug.DrawRay(left, transform.forward * raycastDistance, Color.white);
        Debug.DrawRay(up, transform.forward * raycastDistance, Color.white);
        Debug.DrawRay(down, transform.forward * raycastDistance, Color.white);

        // Raycast Checks
        if (Physics.Raycast(right, transform.forward, out hit, raycastDistance))
        {
            raycastVectorOffset += Vector3.left;
        }
        else if (Physics.Raycast(left, transform.forward, out hit, raycastDistance))
        {
            raycastVectorOffset += Vector3.right;
        }

        if (Physics.Raycast(up, transform.forward, out hit, raycastDistance))
        {
            raycastVectorOffset += Vector3.down;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, raycastDistance))
        {
            raycastVectorOffset += Vector3.up;
        }

        // Rotate Turn 
        if (raycastVectorOffset != Vector3.zero)
        {
            transform.Rotate(raycastVectorOffset * raycastDamping* Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }
}

