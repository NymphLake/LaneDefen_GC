using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int EnemyMaxHealth;
    [SerializeField] private int EnemiesCurrentHealth;
    [SerializeField] private GameManager GameM;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesCurrentHealth = EnemyMaxHealth;
    }
    public void DamageTaken()
    {
        EnemiesCurrentHealth = EnemiesCurrentHealth - 1;

        if(EnemiesCurrentHealth == 0)
        {
            Destroy(gameObject);
            GameM.SlauhterPoints();
        }
    }
}
