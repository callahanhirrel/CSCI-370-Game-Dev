using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 velocity;
    private float speed = 7;
    public Text points;
    public Text lives;
    private Vector2 position;
    public GameObject coin;
    private int point = 0;
    private int curLive = 5;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        points.text = "Points: " + point.ToString();
        lives.text = "Lives: " + curLive.ToString();

        position = new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-4f, 4.5f));
        Instantiate(coin, position, Quaternion.identity);
    }


    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        Vector2 inp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocity = inp.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);

            point = point + 10;

            points.text = "Points: " + point.ToString();

            position = new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-4f, 4.5f));
            Instantiate(coin, position, Quaternion.identity);
        } 
        else if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            curLive -= 1;
            lives.text = "Lives: " + curLive.ToString();
        }
    }
}
