using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject impact;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 maps to left mouse click
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Zombie tar = hit.transform.GetComponent<Zombie>();

            if (tar != null)
            {
                tar.Damage(damage);
                //hit.rigidbody.AddForce(-hit.normal * hitForce);
                //hit.rigidbody.AddForce(hit.transform.forward * hitForce);
            }

            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
