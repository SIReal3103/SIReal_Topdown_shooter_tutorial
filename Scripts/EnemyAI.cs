using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public bool roaming = true;
    public float maxWidthFromPlayer;
    public float maxHeightFromPlayer;

    public float moveSpeed;
    public float nextWPDistance;

    public Seeker seeker;
    public bool updateContinuesPath;

    // Shoot
    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;

    public SpriteRenderer characterSR;

    bool reachDestination = false;
    Path path;
    Coroutine moveCoroutine;

    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.2f);
        reachDestination = true;
    }

    private void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (isShootable &&  fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;
            // Shoot
            EnemyFireBullet();
        }
    }

    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    void CalculatePath()
    {
        Vector2 target = FindTarget();

        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        // Move to target
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;

            if (force.x != 0)
            {
                if (force.x > 0)
                    characterSR.transform.localScale = new Vector3(1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
            }

            yield return null;
        }

        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        if (roaming == true)
        {
            return (Vector2)playerPos + (new Vector2(Random.Range(-1f, 1f) * maxWidthFromPlayer,
                Random.Range(-1f, 1f) * maxHeightFromPlayer));
        }
        else
        {
            return playerPos;
        }
    }

    
}
