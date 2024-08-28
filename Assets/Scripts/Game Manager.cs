using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerlives = 3;
    private int playerscore = 0;
    public float SpawnTimer; 
    [SerializeField] private TMP_Text playerTextLives;
    [SerializeField] private TextMeshProUGUI playerHighScore;
    [SerializeField] private GameObject[] enemytypes;
    [SerializeField] private GameObject[] lanes; 

    // Start is called before the first frame update
    void Start()
    {
        playerlives = 3;
        
        UpdatingScore();
    }
    public void PlayerHealth()
    {
        playerlives = playerlives - 1;
        if (playerlives == 0)
        {
            SceneManager.LoadScene(0);
        }
        playerTextLives.text = "Lives: " + playerlives.ToString();
    }
    public void SlauhterPoints () //When player kills enemy they get points here
    {
        playerscore = playerscore + 115; //Eaiser for my brain to comprehend
        playerHighScore.text = "HighScore: " + playerscore.ToString();
    }
    public void CheckingScore() //Checks to see if a player made a score
    {
        //GetInt Pulls the value/amount the player has got however if the player
        //has not tried this game before it will be 0
        if (playerscore > PlayerPrefs.GetInt("HighScore", 0))
        {
            //Creates a folder on the computer in order to store the point amount
            PlayerPrefs.SetInt("HighScore", playerscore);
            UpdatingScore();
        }
    }
    public void UpdatingScore()
    {
        //This is to update text on when players recive a new high score
        //If the player has NOT played the game before it will be defulted to 0
        playerHighScore.text = $"HighScore {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    public void Update()
    {
        SpawnTimer = SpawnTimer + Time.deltaTime;
        if (SpawnTimer >= 1)
        {
            SpawnTimer = 0;
            int Enemy = Random.Range(0, enemytypes.Length);
            int Lane = Random.Range(0, lanes.Length);
            Instantiate(enemytypes[Enemy], lanes[Lane].transform.position, Quaternion.identity);
        }

    }
}
