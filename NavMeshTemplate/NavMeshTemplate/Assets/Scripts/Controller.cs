using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // necessary to import this when using NavMeshAgent

public class Controller : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 indicates a left click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // so this is a Camera method for a direct ray
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                meshAgent.SetDestination(hit.point);
            }
        }
    }
}
