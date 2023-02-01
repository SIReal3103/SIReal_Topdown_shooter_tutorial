using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public GameObject muzzle;
    public Transform[] spawnPos;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float bulletForce;
    public int minDamage = 6;
    public int maxDamage = 16;

    // Effect Part 10
    public GameObject fireEffect;

    public WeaponManager weaponManager;
    public Transform calculatePoint;

    //private void FixedUpdate()
    //{
    //    Vector2 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);

    //    if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) transform.localScale = new Vector3(1, -1, 0);
    //    else transform.localScale = new Vector3(1, 1, 0);
    //}

    private void Update()
    {
        //UPDATE
        timeBtwShots -= Time.deltaTime;
        if (timeBtwShots <= 0)
        {
            Transform enemy = weaponManager.FindNearestEnemy(calculatePoint.position);
            if (enemy != null)
            {
                RotateGun(enemy.position);
                Fire();
            }
        }
    }

    void RotateGun(Vector3 pos)
    {
        Vector2 lookDir = pos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) transform.localScale = new Vector3(1, -1, 0);
        else transform.localScale = new Vector3(1, 1, 0);
    }

    void Fire()
    {
        // For is for auto fire part
        foreach (Transform spanw in spawnPos)
        {
            Instantiate(muzzle, spanw.position, transform.rotation, transform);
            var bullet = Instantiate(projectile, spanw.position, Quaternion.identity);
            Bullet bulletC = bullet.GetComponent<Bullet>();
            bulletC.minDamage = minDamage;
            bulletC.maxDamage = maxDamage;

            timeBtwShots = startTimeBtwShots;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

            //Part 10
            var fireE = Instantiate(fireEffect, spanw.position, transform.rotation, transform);
        }
    }
}
