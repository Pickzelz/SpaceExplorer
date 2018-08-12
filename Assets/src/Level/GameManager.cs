using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    [HideInInspector] private GameObject _characterSpawn;
    [HideInInspector] private GameObject _characterObject;
    [HideInInspector] private List<GameObject> _enemies = null;

    protected override void Init()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject characterSpawn
    {
        get { return _characterSpawn; }
        set { _characterSpawn = value; }
    }

    public GameObject characterObject
    {
        get { return _characterObject; }
        set { _characterObject = value; }
    }
    
    public List<GameObject> enemies
    {
        get{
            if (_enemies == null)
                _enemies = new List<GameObject>();
            return _enemies;
        }
        set
        {
            _enemies = value;
        }
    }
}
