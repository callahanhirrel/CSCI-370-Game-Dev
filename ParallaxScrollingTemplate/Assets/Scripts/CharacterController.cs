using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 7f;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // get the specified component from the attached GameObject
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        velocity = new Vector2(input * speed, rb2d.velocity.y);
    }
}
