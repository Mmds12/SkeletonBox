using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damageAmount = 20;
    public bool isDead = false;
    public static int kills = 0;
    public static int money = 0;

    public Animator animator;

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            kills++;
            money += 100;
            StartCoroutine(destroyEnemy());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= damageAmount;

            if (health <= 0)
            {
                animator.SetTrigger("death");
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    IEnumerator destroyEnemy()
    {
        isDead = true;
        health = 100;
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
        isDead = false;
    }
}
