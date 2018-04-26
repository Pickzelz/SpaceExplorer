using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float maxThrustPower = 4;
    public float thrustPowerMultiple = 0.1f;

    private float currentThrustPower = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Jump"))
        {
            currentThrustPower += thrustPowerMultiple;
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * currentThrustPower);
        }
        else
        {
            if(currentThrustPower > 0)
                currentThrustPower -= thrustPowerMultiple;
            transform.GetComponent<Rigidbody>().AddForce(Vector3.down * currentThrustPower);
            
        }
	}
}
