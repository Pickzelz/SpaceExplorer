using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ant : MonoBehaviour, IEnemyControl {

    public NavMeshAgent agent;
    public GameObject playerNearby;
    public float attackRange = 100;
    private NavMeshPath m_Path;

    private bool m_isDetectedPlayerNearby = true;

    private void Awake()
    {
        transform.parent.GetComponent<EnemyManager>().enemies.Add(this);
    }

    // Use this for initialization
    void Start () {
        MoveToPlayer();
        
	}
	
	// Update is called once per frame
	void Update () {
		if(m_isDetectedPlayerNearby)
        {
            //agent.SetDestination(playerNearby.transform.position);
            ////agent.stoppingDistance = attackRange;
            //if (agent.remainingDistance < attackRange)
            //    agent.isStopped = true;
            //else
            //    agent.isStopped = false;
        }
	}

    public void Attack()
    {

    }

    public void MoveToPlayer()
    {
        m_isDetectedPlayerNearby = true;
    }

    public bool GetIsDetectedPlayerNearby()
    {
        return m_isDetectedPlayerNearby;
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }

    public GameObject getPlayerNearby()
    {
        return playerNearby;
    }
    public NavMeshPath Getpath()
    {
        if (m_Path == null)
            m_Path = new NavMeshPath();
        return m_Path;
    }

    public Vector3 GetMoveTo()
    {
        //Debug.Log("current position " + transform.position);
        //Debug.Log("next position " + agent.nextPosition);
        Vector3 _result = Vector3.zero;
        //_result = agent. - transform.position;
        //Debug.Log("result " + _result);
        return _result;
    }
}
