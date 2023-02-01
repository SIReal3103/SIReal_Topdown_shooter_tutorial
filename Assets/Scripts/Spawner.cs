using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    public GameObject[] enemies;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randEnemy], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
