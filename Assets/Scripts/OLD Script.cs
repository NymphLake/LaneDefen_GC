using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    /*[SerializeField] private GameObject[] enemytypes;
    [SerializeField] private GameObject[] lanes;


    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;

    [SerializeField] private Transform StartPoint; 

    [SerializeField] private float Enemy1SpawnTime = 20f; //Slime
    [SerializeField] private float Enemy2SpawnTime = 15f; //Cube
    [SerializeField] private float Enemy3SpawnTime = 10f; //Snail
    // Start is called before the first frame update
    void Start()
    {
      *//*  StartCoroutine(spawnEnemy(Enemy1SpawnTime, Enemy1));
        StartCoroutine(spawnEnemy(Enemy2SpawnTime, Enemy2)); 
        StartCoroutine(spawnEnemy(Enemy3SpawnTime, Enemy3)); *//*
    }

    // Update is called once per frame
    public void Update()
    {
        *//*SpawnTimer = SpawnTimer + Time.deltaTime;
        if (SpawnTimer == 5)
        {
            int Enemy = Random.Range(0, enemytypes.Length);
            int Lane = Random.Range(0, lanes.Length);
            Instantiate(enemytypes[Enemy], lanes[Lane].transform.position, Quaternion.identity);
        }*//*


    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, StartPoint.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

*/
}
