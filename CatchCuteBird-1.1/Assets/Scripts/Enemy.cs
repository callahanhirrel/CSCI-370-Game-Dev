using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 6f;
    private Vector2 position;
    private float timeMove = 0.7f;
    private float timeBullet = 1.2f;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(7.92f, Random.Range(-4f, 4f));
    }

    // Update is called once per frame
    void Update()
    {
        timeMove -= Time.deltaTime;
        timeBullet -= Time.deltaTime;


        if (timeMove > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        else
        {
            position = new Vector2(7.92f, Random.Range(-4f, 4f));
            timeMove = 0.7f;
        }

        if (timeBullet <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBullet = 1.2f;
        }
    }
}
