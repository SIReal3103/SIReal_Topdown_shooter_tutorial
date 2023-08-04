using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    public GameObject[] enemies;

    public WeaponManager weaponManager;

    public List<Spawner> spawners;

    private Player player;
    int maxEnemy = 5;
    int roundCount = 0;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public List<int> GetRandomIndices(int n, int k)
    {

        // Create a list containing all indices from 0 to n-1
        List<int> allIndices = new List<int>();
        for (int i = 0; i < n; i++)
        {
            allIndices.Add(i);
        }

        // Create a list to store the randomly selected indices
        List<int> randomIndices = new List<int>();

        // Use Fisher-Yates shuffle algorithm to randomly shuffle the indices
        int remainingItems = n;
        for (int i = 0; i < k; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, remainingItems);
            randomIndices.Add(allIndices[randomIndex]);
            // Move the last index in the list to the current position
            allIndices[randomIndex] = allIndices[remainingItems - 1];
            remainingItems--;
        }

        return randomIndices;
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randEnemyCount = UnityEngine.Random.Range(2, maxEnemy);
            if (weaponManager.Enemies.Count <= 5)
                randEnemyCount = UnityEngine.Random.Range(maxEnemy - 2, maxEnemy);

            List<int> randomIndex = GetRandomIndices(maxEnemy, randEnemyCount);

            foreach(int index in randomIndex)
            {
                int randEnemy = UnityEngine.Random.Range(0, enemies.Length);
                spawners[index].spawnEnemy(enemies[randEnemy]);
            }
            timeBtwSpawn = startTimeBtwSpawn;

            roundCount++;
            if (roundCount > 10)
            {
                roundCount = 0;
                maxEnemy = Mathf.Max(spawners.Count, maxEnemy + 1);
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
