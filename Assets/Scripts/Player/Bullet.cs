﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Wall")
        //{
            
        //}
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<Enemy>().TakeDamage(25);
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.instance.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
