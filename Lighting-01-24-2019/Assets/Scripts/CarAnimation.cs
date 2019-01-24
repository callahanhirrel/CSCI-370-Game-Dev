using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimation : MonoBehaviour {

    public GameObject HeadLights;
    //public GameObject BackLights; 
    //public GameObject InteriorLights;
    public GameObject LeftDoor;
    public GameObject RightDoor;

    public Light spotLeft, spotRight, pointLeft, pointRight;

    bool leftDoorFlag = false;
    bool rightDoorFlag = false;
    bool headlightFlag = false;
    bool brightsFlag = false;

    // Use this for initialization
    void Start () {
        // Turn off all lights 
        HeadLights.SetActive(false);
        //BackLights.SetActive(false);
        //InteriorLights.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(leftDoorFlag == false)
            {
                LeftDoor.transform.Rotate(0f, 45f, 0f);
                //InteriorLights.SetActive(true);
                leftDoorFlag = true;
            }
            else
            {
                LeftDoor.transform.Rotate(0f, -45f, 0f);
                //InteriorLights.SetActive(false);
                leftDoorFlag = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rightDoorFlag == false)
            {
                RightDoor.transform.Rotate(0f, -45f, 0f);
                //InteriorLights.SetActive(true);
                rightDoorFlag = true;
            }
            else
            {
                RightDoor.transform.Rotate(0f, 45f, 0f);
                //InteriorLights.SetActive(false);
                rightDoorFlag = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(headlightFlag == false)
            {
                HeadLights.SetActive(true);
                headlightFlag = true;
            }
            else
            {
                HeadLights.SetActive(false);
                headlightFlag = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (brightsFlag == false && headlightFlag == true)
            {
                spotLeft.intensity = 30;
                spotRight.intensity = 30;
                brightsFlag = true;
            }
            else
            {
                spotLeft.intensity = 1;
                spotRight.intensity = 1;
                brightsFlag = false;
            }
        }
    }
}
