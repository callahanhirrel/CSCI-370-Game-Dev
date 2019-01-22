using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNanners : MonoBehaviour {

    public Rigidbody rbNanner0;
    public Rigidbody rbNanner1;
    public Rigidbody rbNanner2;
    public Rigidbody rbNanner3;
    public Rigidbody rbNanner4;
    public Rigidbody rbNanner5;
    public Rigidbody rbNanner6;
    public Rigidbody rbNanner7;
    public Rigidbody rbNanner8;
    public Rigidbody rbNanner9;
    public Rigidbody rbNanner10;

    // Use this for initialization
    void Start () {
        rbNanner0.AddForce(Random.Range(0, 100), 0, 0);
        rbNanner1.AddForce(Random.Range(0, 100), Random.Range(0, 100), 0);
        rbNanner2.AddForce(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
        rbNanner3.AddForce(Random.Range(0, 100), 0, Random.Range(0, 100));
        rbNanner4.AddForce(0, 0, Random.Range(0, 100));
        rbNanner5.AddForce(0, Random.Range(0, 100), 0);
        rbNanner6.AddForce(Random.Range(0, 100), Random.Range(0, 100), 0);
        rbNanner7.AddForce(Random.Range(0, 100), 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
