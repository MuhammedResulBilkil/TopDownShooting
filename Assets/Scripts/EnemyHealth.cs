﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 5;
    public AnimationClip deathAnim;

    EnemyMovement enemyMovement;
    Rigidbody2D rb2d;
    AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        deathSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ChangeHealth(-2);
        }
    }

    public void ChangeHealth(int damage)
    {
        enemyHealth += damage;

        if (enemyHealth <= 0)
            EnemyDie();
    }

    private void EnemyDie()
    {
        rb2d.velocity = Vector2.zero;
        enemyMovement.isDeath = true;
        enemyMovement.anim.SetTrigger("Death");

        deathSound.Play();
        
        Destroy(gameObject, deathAnim.length);
    }
}
