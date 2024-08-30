using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyIncoming : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RIG2D;
    [SerializeField] private float Speed;//Normal EnemmySpeed
    [SerializeField] private float StunnedSped; //Speed when hit
    [SerializeField] private GameManager gameManager;
    [SerializeField] EnemyHealth health;
    public float StunTime;
    public float Timer;
    public float transfersped;
    private bool stunnedwaittime;
    public void Start()
    {
        transfersped = Speed;
        StunTime = 0.4f;
        Timer = 0;
    }
    public void FixedUpdate()
    {
        RIG2D.velocity = new Vector2(-transfersped * Time.deltaTime, 0);
        
    }
    public void Update()
    {
        if(stunnedwaittime == true)
        {
            Timer += Time.deltaTime;
            if(Timer >= StunTime)
            {
                transfersped = Speed;
                Timer = 0; 
                stunnedwaittime = false;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
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
            Destroy(collision.gameObject);
            transfersped = StunnedSped;
            stunnedwaittime = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
           

        }
    }
}
