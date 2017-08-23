using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour
{
    Transform target;
    Animator enemy;
    NavMeshAgent agent;
    public int enemyMaxHeath = 4;
    int enemyHeath;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        enemy = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        enemyHeath = Random.Range(1, enemyMaxHeath);
    }

    void Update()
    {
        if (enemy.GetBool("Dead"))
        {
            agent.enabled = false;
            Destroy(gameObject, 1.5f);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            if (enemyHeath != 0)
            {
                enemy.SetTrigger("Hit");

                enemyHeath = enemyHeath - 1;

                if (enemyHeath == 0)
                {
                    enemy.SetBool("Dead", true);
                }
            }
        }
    }
}
