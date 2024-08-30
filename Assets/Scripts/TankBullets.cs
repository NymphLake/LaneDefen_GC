using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankBullets : MonoBehaviour
{
    public Animator BulletTest;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Test") //The invisable wall to destroy bullets
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {

            BulletTest.SetBool("Attempt", true);
        }
    }
    //Utilized with the events system for the animation to destroy the bullet once it completes the animation
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}