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
    private InputAction spaceAttack;
    private InputAction Restart;
    private InputAction Quit;
    private GameManager gameManager;
    public AudioClip FiringSound; //For destorying enemy
    public Animator BulletAnimation;
    private float BulletSpeed = 2f; 
    private float speed;
    private float playerButtonData;
    private bool playerMomentum;
    private float delaytime = 0.5f; //Delay of the holding down space speed
    private bool spacepressed;
    public float Stopwatch; //Timer that counts up, need public to monitor
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
        spacepressed = false;
    }
   
    private void SpaceBarAttack(InputAction.CallbackContext context)
    {
        spacepressed = true;
        Stopwatch = 7;
    }
    public void BulletSpawner()
     {
        //This is to help put all the data into the game object to make copies off 
        GameObject BulletLaunch = Instantiate(Bullet,locationBullet.position, locationBullet.rotation);   
        //So then when it is good to launch it will use force and speed to send it into a specific diretion
        BulletLaunch.GetComponent<Rigidbody2D>().AddForce(locationBullet.right * BulletSpeed, ForceMode2D.Impulse);
        GetComponent<AudioSource>().PlayOneShot(FiringSound);
     }
    private void PlayerStoppedMove(InputAction.CallbackContext context)
    {
       playerMomentum = false;
    }

    private void QuitGame(InputAction.CallbackContext context)
    {
        Application.Quit(); //Do not make it spacebar
    }

    private void RestartedGame(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    private void PlayerSequence(InputAction.CallbackContext context)
    {
        playerMomentum = true;
    }
    #endregion

    #region
    public void Update()
    {
        if (spacepressed == true)
        {
            Stopwatch += Time.deltaTime;
            //If the time is more than the delay time then bullets will spawn
            //then the stopwatch will be brought back to 0 to get ready for 
            //more bullets
            if (Stopwatch > delaytime)
            { 
                BulletSpawner();
                Stopwatch = 0; 
            }
        }
    }
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
    #endregion
}
