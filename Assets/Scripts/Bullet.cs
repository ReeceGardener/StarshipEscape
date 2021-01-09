using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);

        Destroy(impactEffect, 5f);
        Destroy(gameObject);
    }
}
