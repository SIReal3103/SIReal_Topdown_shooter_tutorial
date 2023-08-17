using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject damPopUp;

    Health health;
    ColoredFlash flash;

    private void Start()
    {
        health = GetComponent<Health>();
        flash = GetComponent<ColoredFlash>();
    }

    public void TakeDamage(int damage)
    {
        if (damPopUp != null)
        {
            GameObject instance = Instantiate(damPopUp, transform.position
                    + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 0.5f, 0), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Animator animator = instance.GetComponentInChildren<Animator>();
            if (damage <= 10) animator.Play("normal");
            else animator.Play("critical");
        }

        // Flash
        if (flash != null)
        {
            flash.Flash(Color.white);
        }

        health.TakeDam(damage);
        // Freeze
        //if (enemyAI != null)
        //{
        //    enemyAI.FreezeEnemy();
        //}
    }

    // Video 12 - collision with player
    Player PlayerS;
    public int minDamage;
    public int maxDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerS = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("DamagePlayer");
            PlayerS = null;
        }
    }

    void DamagePlayer()
    {
        int damage = Random.Range(minDamage, maxDamage);
        PlayerS.TakeDamage(damage);
    }
}
