using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyIncoming : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RIG2D;
    [SerializeField] private float Speed;
    [SerializeField] private GameManager gameManager;
    public float StunTime;
    [SerializeField] EnemyHealth health;
    private void FixedUpdate()
    {
        RIG2D.velocity = new Vector2(-Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death Wall")
        {
            gameManager.PlayerHealth();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            gameManager.PlayerHealth();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            health.DamageTaken();
            Destroy(gameObject);
            
/*            RIG2D.velocity = new Vector2(0 * Time.deltaTime, 0);

            if (StunTime >= 3)
            {
                RIG2D.velocity = new Vector2(-Speed * Time.deltaTime, 0);
                StunTime = 0;
            }
*/
        }
    }

}
