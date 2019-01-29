using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCamera : MonoBehaviour {

    public Transform transformObject;
    private Vector3 distance;
    private float smooth;

	// Use this for initialization
	void Start () {
        distance = transform.position - transformObject.position;
        smooth = 0.5f;
    }
	
	// LateUpdate is called once per frame calls itself AFTER regular Update()
	void LateUpdate () {
        Vector3 newPosition = transformObject.position + distance;
        transform.position = Vector3.Slerp(transform.position, newPosition, smooth); 
        // Slerp gives us smooth movement, instead of hard jumpiness
	}
}
