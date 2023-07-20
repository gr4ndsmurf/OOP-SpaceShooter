using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public int numberOfPowerUpToSpawn = 3;
    public float spawnInterval = 3f;
    public List<Transform> spawnPoints;
    public List<Transform> powerUpPoints = new List<Transform>();

    private float timer = 0f;

    private void Start()
    {
        powerUpPoints = new List<Transform>(spawnPoints);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            for (int i = 0; i < numberOfPowerUpToSpawn; i++)
            {
                SpawnPowerUp();
            }
            powerUpPoints = new List<Transform>(spawnPoints);
            timer = 0f;
        }
    }

    private void SpawnPowerUp()
    {
        Transform spawnPoint = powerUpPoints[Random.Range(0, powerUpPoints.Count)];
        GameObject powerUp = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];
        Instantiate(powerUp, spawnPoint.position, powerUp.transform.rotation);
        powerUpPoints.Remove(spawnPoint);
    }
}
