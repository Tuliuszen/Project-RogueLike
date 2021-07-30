using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int numberOfEnemiesInRoom = 3;
    [SerializeField] GameObject[] enemiesToSpawn;

    float xPos, yPos;
    [SerializeField]float roomHeight = 8, roomWidth = 8;
    
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesInRoom; i++)
        {
            GameObject enemy = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];

            xPos = Random.Range(0, roomWidth);
            yPos = Random.Range(0, roomHeight);

            Vector2 enemyPosition = new Vector2(xPos, yPos);

            Instantiate(enemy, enemyPosition, Quaternion.identity);
        }
    }
    
}
