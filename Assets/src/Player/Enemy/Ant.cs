using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ant : MonoBehaviour, IEnemyControl {

    enum e_state { STATE_IDLE, STATE_FOUND_SOMETHING, STATE_PROCESS_TO_NEXT_ACTION, STATE_ATTACK_TARGET, STATE_CHASE_TARGET, STATE_BACK_TO_POSITION}

    public NavMeshAgent agent;
    public float attackRange = 100;
    public float detectionRange = 100;

    private NavMeshPath m_Path;
    private e_state state;
    private bool m_isDetectedPlayerNearby = true;
    private Vector3? destinationTarget = null;
    private Vector3? firstPosition = null;
    private GameObject target = null;

    //private function
    private void Awake()
    {
        //transform.parent.GetComponent<EnemyManager>().enemies.Add(this);
    }

    void Start () {
        MoveToPlayer();
        state = e_state.STATE_IDLE;
        firstPosition = transform.position;
	}
	
	void FixedUpdate () {
        detectNearby();
        PlayStateMachine();
	}

    void OnDrawGizmosSelected()
    {
        Color c = Color.red;
        Gizmos.color = c;
        Gizmos.DrawWireSphere(transform.position, attackRange/2);

        Color d = Color.blue;
        Gizmos.color = d;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Color e = Color.green;
        Gizmos.color = e;
        if (firstPosition != null)
            Gizmos.DrawWireSphere((Vector3)firstPosition, 2);
    }

    private void detectNearby()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        bool playerFound = false;
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.tag == "Player")
                {
                    if (state == e_state.STATE_IDLE || state == e_state.STATE_BACK_TO_POSITION)
                    {
                        target = hitColliders[i].gameObject;
                        
                        state = e_state.STATE_FOUND_SOMETHING;
                    }
                    playerFound = true;
                }
            }
        }

        if (destinationTarget != null)
        {
            agent.SetDestination((Vector3)destinationTarget);
        }

        if(!playerFound && firstPosition != null)
        {
            state = e_state.STATE_BACK_TO_POSITION;
        }
    }

    private void PlayStateMachine()
    {
        switch (state)
        {
            case e_state.STATE_IDLE:
                agent.isStopped = true;
                destinationTarget = null;
                break;

            case e_state.STATE_FOUND_SOMETHING:
                state = e_state.STATE_PROCESS_TO_NEXT_ACTION;
                break;

            case e_state.STATE_PROCESS_TO_NEXT_ACTION:
                state = e_state.STATE_CHASE_TARGET;

                break;
            case e_state.STATE_CHASE_TARGET:
                agent.isStopped = false;
                destinationTarget = target.transform.position;
                if (agent.remainingDistance < attackRange)
                    state = e_state.STATE_ATTACK_TARGET;

                break;
            case e_state.STATE_ATTACK_TARGET:

                agent.isStopped = true;
                destinationTarget = target.transform.position;
                if (agent.remainingDistance > attackRange)
                    state = e_state.STATE_CHASE_TARGET;
                else
                    Attack();

                break;
            case e_state.STATE_BACK_TO_POSITION:
                if (firstPosition != null)
                {
                    destinationTarget = (Vector3)firstPosition;
                }

                if (agent.remainingDistance == 0)
                {
                    state = e_state.STATE_IDLE;
                }

                break;
        }
    }


    //end private

    // public function 
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
        return target;
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

    //end public

   
}
