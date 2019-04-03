using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingAndParallax : MonoBehaviour
{
    public Camera cam;
    public float bgSize;
    public float parallaxSpeed;

    private Transform camTrans;
    private Transform[] layers;
    private float viewZone = 5f;
    private int leftIndex;
    private int rightIndex;
    private float camPos;

    // Start is called before the first frame update
    void Start()
    {
        // Scrolling
        camTrans = cam.transform;
        layers = new Transform[transform.childCount];

        for (int i=0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = transform.childCount - 1;

        // Parallax
        camPos = camTrans.position.x;
    }

    private void ScrollLeft()
    {
        layers[rightIndex].position = new Vector2((layers[leftIndex].position.x - bgSize), layers[leftIndex].position.y);

        leftIndex = rightIndex;
        rightIndex = rightIndex - 1;
        // this if-statement lets you rotate the indices correctly
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        layers[leftIndex].position = new Vector2((layers[rightIndex].position.x + bgSize), layers[rightIndex].position.y);
        rightIndex = leftIndex;
        leftIndex = leftIndex + 1;
        if (leftIndex >= layers.Length)
        {
            leftIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Scrolling
        if (camTrans.position.x < layers[leftIndex].position.x + viewZone)
        {
            ScrollLeft();
        }
        if (camTrans.position.x > layers[rightIndex].position.x - viewZone)
        {
            ScrollRight();
        }

        // Parallax
        float offset = camTrans.position.x - camPos;
        transform.position += new Vector3(offset * parallaxSpeed, 0); // Vector3 or Vector2?
        camPos = camTrans.position.x;
    } 
}
