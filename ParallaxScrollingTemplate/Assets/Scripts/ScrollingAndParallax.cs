using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingAndParallax : MonoBehaviour
{
    public Camera cam;
    public float bgSize;
    private Transform camTrans;
    private Transform[] layers;
    private float viewZone = 5f;
    private int leftIndex;
    private int rightIndex;
    private float camPos;

    // Start is called before the first frame update
    void Start()
    {
        camTrans = cam.transform;
        layers = new Transform[transform.childCount];

        for (int i=0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = transform.childCount - 1;
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
        if (camTrans.position.x < layers[leftIndex].position.x + viewZone)
        {
            ScrollLeft();
        }
        if (camTrans.position.x > layers[rightIndex].position.x - viewZone)
        {
            ScrollRight();
        }
    }
}
