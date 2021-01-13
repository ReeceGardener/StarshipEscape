using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(obj: impactEffect, t: 0.5f);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy.instance.TakeDamage(25);
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.instance.TakeDamage(50);
        }
        Destroy(gameObject);
    }
}
