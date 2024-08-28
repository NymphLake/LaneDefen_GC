using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankBullets : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.tag == "Test") //The invisable wall to destroy bullets
        {
            Destroy(gameObject);
        }

    }
}