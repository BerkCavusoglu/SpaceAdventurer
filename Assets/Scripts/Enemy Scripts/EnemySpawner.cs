using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y = -4.3f, max_Y = 4.3f;
    public GameObject[] asteroid_Prefabs;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2; 
    public float timer = 1f;

    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 3; i++)  
        {
            float pos_Y = Random.Range(min_Y, max_Y);
            Vector3 temp = transform.position;
            temp.y = pos_Y;

            int randomEnemy = Random.Range(0, 3); 

            if (randomEnemy == 0)
            {
                Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)], temp, Quaternion.identity);
            }
            else if (randomEnemy == 1)
            {
                Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
            }
            else if (randomEnemy == 2)
            {
                
                Instantiate(enemyPrefab2, temp, Quaternion.Euler(0f, 0f, 90f));
            }
        }

        Invoke("SpawnEnemies", timer);
    }
}
