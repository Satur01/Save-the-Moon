﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable<int>, IKillable
{
    Rigidbody2D rgb2D;

    public EnemyScriptableData EnemeyStats;
    public int Speed, EnemyDamage, Life;
    public float ShootRate;

    public float offset { get; set; }
    public Wave.WaveType typeOfWave { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Speed = EnemeyStats.movementSpeed;
        EnemyDamage = EnemeyStats.damage;
        ShootRate = EnemeyStats.shootRate;
        Life = EnemeyStats.life;

        rgb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (typeOfWave)
        {
            case Wave.WaveType.Pattern:
                PatternMovement();
                break;
            case Wave.WaveType.Stationary:
                break;
            default: break;
        }
        
    }

    void FixedUpdate()
    {
        rgb2D.AddForce(Vector2.down * 0.2f, ForceMode2D.Force);
    }

    private void PatternMovement()
    {
        float x = 2f * Mathf.Sin(Time.time * 1f + offset);
        transform.position = new Vector2(x, transform.position.y);
    }    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player Laser"))
        {
            Shoot shooterInstance = other.transform.parent.GetComponent<Shoot>();

            if (shooterInstance.damage - Life <= 0)
            {
                Kill();
            }
            else
            {
                Damage(shooterInstance.damage);
            }
        }
    }

    public void Damage(int damageTaken)
    {
        Life = Life - damageTaken;
        //Play Damage animation
    }

    public void Kill()
    {
        //Explosion animation
        Destroy(this.gameObject);
    }
}
