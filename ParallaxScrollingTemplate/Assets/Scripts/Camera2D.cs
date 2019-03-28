using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public GameObject knight;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - knight.transform.position;
    }

    // You generally wanna use LateUpdate() for moving the camera
    void LateUpdate()
    {
        transform.position = knight.transform.position + offset;
    }
}
