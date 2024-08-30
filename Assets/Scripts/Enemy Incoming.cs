using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyIncoming : MonoBehaviour
{
    #region
    [SerializeField] private Rigidbody2D RIG2D;
    [SerializeField] private float Speed;//Normal EnemmySpeed
    [SerializeField] private float StunnedSped; //Speed when hit
    [SerializeField] private GameManager gameManager;
    [SerializeField] EnemyHealth health;
    public Animator EnemyAnimation;
    public Animator BulletAnimation;
    private bool stunnedwaittime;
    public float StunTime; //Time when they are stunned
    public float Timer; //Counts up
    public float transfersped;
    #endregion
    public void Start()
    {
        transfersped = Speed;//Giving speed to something else to be saved for later
        StunTime = 0.5f;//How long they remain stunned/stopped
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
                EnemyAnimation.SetBool("GotHit", false);
                stunnedwaittime = false;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death Wall") //The barriers at the end/ behind the spawning enemies
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
            transfersped = StunnedSped;
            stunnedwaittime = true;
            EnemyAnimation.SetBool("GotHit", true);
        }
    }
}
