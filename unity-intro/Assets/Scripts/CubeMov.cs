using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMov : MonoBehaviour {

    public Rigidbody rbCube;
    public Rigidbody rbSphere;

	// Use this for initialization
	void Start () {
        //rbCube.useGravity = false;
        //rbCube.AddForce(0, 200, 200);
    }
	
	// Update is called once per frame
	void Update () {
        //rbCube.AddForce(0, 10, 0);
	}

    private void FixedUpdate()
    {
        rbCube.AddForce(0, 0, 1000 * Time.deltaTime);
    }
}
