using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public FICharacter control;
    public FIWeapon weapon;

    [Header("Character Status")]
    public int Health = 100;

    //private
    private Vector3 bulletVelocity;
    private GameManager _manager;

	// Use this for initialization
	void Start () {
        _manager = GameManager.Instance;
        _manager.characterObject = gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnDrawGizmos()
    {

        

    }
}
