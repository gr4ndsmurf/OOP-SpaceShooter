using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyShipPrefab;
    public int numberOfEnemiesToSpawn = 3;
    public float spawnInterval = 3f;
    public Transform[] enemyPoints;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                SpawnEnemyShip();
            }
            timer = 0f;
        }
    }

    private void SpawnEnemyShip()
    {
        Transform spawnPoint = enemyPoints[Random.Range(0, enemyPoints.Length)];
        GameObject newEnemyShip = Instantiate(enemyShipPrefab, spawnPoint.position, Quaternion.identity);
    }
}
