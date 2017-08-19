using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateController : MonoBehaviour
{
    public AIState currentState;
    public AIState sameState;
    public SimpleEnemy simpleEnemy;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public List<Transform> waypointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
