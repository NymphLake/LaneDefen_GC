using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerTextLives;
    [SerializeField] private TMP_Text PlayerScore;
    [SerializeField] private TextMeshProUGUI playerHighScore;
    [SerializeField] private GameObject[] enemytypes;
    [SerializeField] private GameObject[] lanes;
    private int playerlives = 3;
    public int playerscore = 0;
    public float SpawnTimer; 
    public AudioClip PlayerHurt;
    //public int enemysetpoints = 115; 

    // Start is called before the first frame update
    void Start()
    {
        playerlives = 3;
        playerscore = 0;
    }
    public void AddingPointsToScore()
    {
        playerscore = playerscore + 115;
    }
    public void ProvingHighScore() //To test to see if it beats the old high score
    {
        if (PlayerPrefs.HasKey("HighScore")) //This checks to see if there is already a high score
        {
            //Below checks to see if the high score has already beaten the previous one
            if (playerscore > PlayerPrefs.GetInt("HighScore"))
            {
                //Sets a new highscore here if it does beat the previous one
                PlayerPrefs.SetInt("HighScore", playerscore);
            }
        }
        else
        {
            //If NO highscore it goes here and sets it with SetInt with player score
            //The reason why it is the same as the previous one is because both 
            //help set the high score. The other one is for already existing high score 
            //while this one is for new high score 
            PlayerPrefs.SetInt("HighScore", playerscore);
        }

        //Calling the scores by using GetInt 
       playerHighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
       //THIS BELOW IS IMPORTANT INCLUDE IT and makes it eaiser to compare if the scores are updating or not
       PlayerScore.text = "Score: " + playerscore.ToString();
    }
    public void PlayerHealth()
    {
        AudioSource.PlayClipAtPoint(PlayerHurt, transform.position);
        playerlives = playerlives - 1;
        if (playerlives == 0)
        {
            SceneManager.LoadScene(0);
        }
        playerTextLives.text = "Lives: " + playerlives.ToString();
    }
    public void FixedUpdate()
    {
        //Called here to continue updating the highscore once exceeds 
        ProvingHighScore();
    }
    public void Update()
    {
        SpawnTimer = SpawnTimer + Time.deltaTime;
        if (SpawnTimer >= 1.15f)
        {
            SpawnTimer = 0;
            int Enemy = Random.Range(0, enemytypes.Length);
            int Lane = Random.Range(0, lanes.Length);
            Instantiate(enemytypes[Enemy], lanes[Lane].transform.position, Quaternion.identity);
        }
    }
}
