using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    Transform target;
    Animator enemy;
    UnityEngine.AI.NavMeshAgent agent;
    public int enemyMaxHeath = 4;
    int enemyHeath;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        enemy = GetComponentInChildren<Animator>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        enemyHeath = Random.Range(2, enemyMaxHeath);
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
                
            if (enemyHeath != 0)
            {
                enemyHeath = enemyHeath - 1;
                enemy.Play("EnemyFlash");

                if (enemyHeath == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
