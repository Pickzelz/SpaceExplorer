using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public GameObject objectFollow;
    public float distanceWithObject = 10f;

	// Use this for initialization
	void Start () {
		
	}
    private void FixedUpdate()
    {
        Vector3 _cameraPosition = objectFollow.transform.position;
        _cameraPosition.x += distanceWithObject;
        transform.position = _cameraPosition;
        transform.LookAt(objectFollow.transform);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
