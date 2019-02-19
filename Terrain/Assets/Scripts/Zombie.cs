using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    float health = 60f;
    float walkRange = 15f;
    float attackRange = 2f;
    float distance;
    int die = 0; // 0 = alive, 1 = dead
    float speed;
    Vector3 position;

    public Animator anim; // Animator is the Animator Controller
    public GameObject fps; // fps is the player character
    public GameObject enemy;
    public GameObject zombie;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.02f;
        anim = zombie.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die == 1)
        {
            // Do not call any animation
        }
        else
        {
            distance = Vector3.Distance(fps.transform.position, transform.position);

            if (distance < attackRange)
            {
                transform.LookAt(fps.transform);
                anim.Play("attack");
            } 
            else if (distance < walkRange)
            {
                transform.LookAt(fps.transform);
                transform.position = Vector3.MoveTowards(transform.position, fps.transform.position, speed);
                anim.Play("walk");
            }
        }
    }

    public void Damage(float amt)
    {
        health -= amt;

        if (health <= 0f)
        {
            die = 1;
            anim.Play("fallingback");
        }
    }
}
