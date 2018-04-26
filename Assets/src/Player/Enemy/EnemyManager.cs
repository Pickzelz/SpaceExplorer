using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

    private List<IEnemyControl> m_Enemies;
    

    // Use this for initialization
    void Start () {
        foreach (IEnemyControl _enemy in m_Enemies)
        {
            if (_enemy.GetIsDetectedPlayerNearby())
            {
                //Debug.Log("path " + _enemy.getPlayerNearby().transform.position);
                Vector3 desPosition = _enemy.getPlayerNearby().transform.position;
                desPosition.y = 15;
                _enemy.GetAgent().CalculatePath(desPosition, _enemy.Getpath());

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        bool startMove = true;
        foreach (IEnemyControl _enemy in m_Enemies)
        {
            if(_enemy.GetAgent().pathPending)
            {
                
                startMove = false;
                break;
            }
        }

        if(startMove)
        {
            foreach (IEnemyControl _enemy in m_Enemies)
            {
                _enemy.GetAgent().SetPath(_enemy.Getpath());
            }
        }
	}

    public List<IEnemyControl> enemies
    {
        get {
            if (m_Enemies == null)
                m_Enemies = new List<IEnemyControl>();
            return m_Enemies;
        }
    }


} 
