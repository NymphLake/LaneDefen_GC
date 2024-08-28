using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    #region
    [SerializeField] private PlayerInput PlayerMovement;
    [SerializeField] private InputAction PlayerLetMove;
    [SerializeField] private Rigidbody2D RIG2D;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform locationBullet;
    //public TankBullets SpeedOfBull;
    private float BulletSpeed = 2f; 
    private InputAction spaceAttack;
    private InputAction Restart;
    private InputAction Quit;
    private Vector3 player; 
    private float speed;
    public float TimeTime;
    private float playerButtonData;
    private bool playerMomentum;
    private float countertime;
    private GameObject gObject;
    private float delaytime = 1f;
    private bool spacepressed;
    private GameManager gameManager;
    #endregion
    void Start()
    {
        
        RIG2D = GetComponent<Rigidbody2D>();
        speed = 8;
        BulletSpeed = 10f;
        
    }
    private void OnEnable()
    {
        PlayerMovement = GetComponent<PlayerInput>();
        RIG2D = GetComponentInChildren<Rigidbody2D>();
        PlayerMovement.currentActionMap.Enable();
        PlayerLetMove = PlayerMovement.currentActionMap.FindAction("MovingAction");
        spaceAttack = PlayerMovement.currentActionMap.FindAction("SpaceAttack");
        Restart = PlayerMovement.currentActionMap.FindAction("Restart");
        Quit = PlayerMovement.currentActionMap.FindAction("Quit");
        PlayerLetMove.canceled += PlayerStoppedMove;
        PlayerLetMove.started += PlayerSequence;
        Restart.started += RestartedGame;
        Quit.started += QuitGame;
        spaceAttack.started += SpaceBarAttack;
        spaceAttack.canceled += SpaceBarCancel;
    }
 #region
    private void SpaceBarCancel(InputAction.CallbackContext context)
    {
        Debug.Log("Space up");
        spacepressed = false;
    }
   
    private void SpaceBarAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Space down");
        spacepressed = true;
        TimeTime = 7;
    }

    //APPLE1
     public void Tester()
     {
        Debug.Log("Spawn Bullet");
        GameObject Apple = Instantiate(Bullet,locationBullet.position, locationBullet.rotation);
        Apple.GetComponent<Rigidbody2D>().AddForce(locationBullet.right * BulletSpeed, ForceMode2D.Impulse);
     }

    private void PlayerStoppedMove(InputAction.CallbackContext context)
    {
       playerMomentum = false;
    }

    private void QuitGame(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void RestartedGame(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    private void PlayerSequence(InputAction.CallbackContext context)
    {
        playerMomentum = true;
    }

    public void SequenceTry()
    {
        Debug.Log("Doki");


        countertime += Time.deltaTime;

        //ReadValue will determine the input the key is pressed
        //If key is completly pressed it will be 1 
        //Half pressed 0.5
        //No press is 0
       /* bool isSpaceHeld = spaceAttack.ReadValue<float>() > 0.1f; 

        if (isSpaceHeld)
        {
            
            if (countertime > delaytime)
            {
                Destroy(Instantiate(gObject, transform.position, Quaternion.identity),
                30f);
                countertime = 0;
            }
        }*/
    }
    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerMomentum == true)
        {
            playerButtonData = PlayerLetMove.ReadValue<float>();
            RIG2D.velocity = new Vector2(0, playerButtonData * speed);
        }
        else
        {
            RIG2D.velocity = new Vector2(0, 0);
        }
    }
    public void Update()
    {
        if (spacepressed == true)
        {
           
            TimeTime += Time.deltaTime;

            if (TimeTime > delaytime)
            { 
                Tester();
                Debug.Log("Timer reset");
                TimeTime = 0;
               
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.PlayerHealth();
        }
    }
    public void OnDestroy()
    {
        PlayerLetMove.started -= PlayerSequence;
        PlayerLetMove.canceled -= PlayerStoppedMove;
        spaceAttack.started -= SpaceBarAttack;
        spaceAttack.canceled -= SpaceBarCancel;

    }
}
