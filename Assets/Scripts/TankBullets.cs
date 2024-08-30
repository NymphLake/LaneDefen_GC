using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankBullets : MonoBehaviour
{
    public Animator BulletAnimation;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Test") //The invisable wall to destroy bullets
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            BulletAnimation.SetBool("BulletExplode", true);

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        BulletAnimation.SetBool("BulletExplode", false);
    }
}