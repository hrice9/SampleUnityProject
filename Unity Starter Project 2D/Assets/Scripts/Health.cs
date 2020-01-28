using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void Die()
    {
        Destroy(gameObject, 0);
    }
}
