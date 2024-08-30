using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    #region
    [SerializeField] private int EnemyMaxHealth;
    [SerializeField] private int EnemiesCurrentHealth;
    [SerializeField] private GameManager GameM;
    public AudioClip EnemyHurt;
    public AudioClip DeathEnemy;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        EnemiesCurrentHealth = EnemyMaxHealth;
    }
    public void DamageTaken()
    {
        AudioSource.PlayClipAtPoint(EnemyHurt, transform.position);
        EnemiesCurrentHealth = EnemiesCurrentHealth - 1;
        if(EnemiesCurrentHealth == 0)
        {
            AudioSource.PlayClipAtPoint(DeathEnemy, transform.position);
            Destroy(gameObject);
            GameM.AddingPointsToScore();
        }
    }
}
