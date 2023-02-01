using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Transform> Enemies = new List<Transform>();

    public void AddEnemyToFireRange(Transform transform)
    {
        Health enemyHealth = transform.GetComponent<Health>();
        if (!enemyHealth.isDead)
            Enemies.Add(transform);
    }

    public void RemoveEnemyToFireRange(Transform transform)
    {
        Enemies.Remove(transform);
    }

    public Transform FindNearestEnemy(Vector2 weaponPos)
    {
        if (Enemies != null && Enemies.Count <= 0) return null;
        Transform nearestEnemy = Enemies[0];
        foreach (Transform enemy in Enemies)
        {
            if (Vector2.Distance(enemy.position, weaponPos) < Vector2.Distance(nearestEnemy.position, weaponPos))
                nearestEnemy = enemy;
        }

        return nearestEnemy;
    }
}
