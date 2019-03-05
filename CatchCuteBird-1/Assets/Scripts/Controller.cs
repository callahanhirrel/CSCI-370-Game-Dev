using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 velocity;
    private Vector2 position;
    private int point = 0;

    public float speed = 10;
    public Text points;
    public Text lives;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;

        points.text = "Points: 0";
        lives.text = "Lives: 0";

        position = new Vector2(Random.Range(5f, 20f), Random.Range(-5f, 1f));
        Instantiate(coin, position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocity = inp.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            point += 10;

            points.text = "Points: " + point.ToString();

            position = new Vector2(Random.Range(5f, 20f), Random.Range(-5f, 1f));
            Instantiate(coin, position, Quaternion.identity);
        }
    }
}
