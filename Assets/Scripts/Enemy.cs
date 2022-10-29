using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    public float maxHealth = 1;
    public float health = 1;

    [System.NonSerialized] public SpriteRenderer enemyRenderer;
    [System.NonSerialized] public Rigidbody2D enemyBody;

    void Start() {
        enemyRenderer = GetComponent<SpriteRenderer>();
        enemyBody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }

}
