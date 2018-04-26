using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemyControl {

    void MoveToPlayer();
    void Attack();

    bool GetIsDetectedPlayerNearby();
    NavMeshAgent GetAgent();
    GameObject getPlayerNearby();
    NavMeshPath Getpath();
    Vector3 GetMoveTo();
}
