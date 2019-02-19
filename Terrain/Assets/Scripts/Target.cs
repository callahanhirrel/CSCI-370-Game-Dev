using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 60f;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Damage(float amount)
    {
        health = health - amount;

        if (health <= 0f)
        {
            Die();
        }
    }
}
