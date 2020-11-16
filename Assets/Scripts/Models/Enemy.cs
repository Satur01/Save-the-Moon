using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rgb2D;

    public EnemyScriptableData EnemeyStats;
    public int Speed, Damage, Life;
    public float ShootRate;

    // Start is called before the first frame update
    void Start()
    {
        Speed = EnemeyStats.movementSpeed;
        Damage = EnemeyStats.damage;
        ShootRate = EnemeyStats.shootRate;
        Life = EnemeyStats.life;

        rgb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 2f * Mathf.Sin(Time.time * 1f);
        transform.localPosition = new Vector2(x, transform.position.y);
    }

    void FixedUpdate()
    {
        rgb2D.AddForce(Vector2.down * 0.2f, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player Bullet"))
        {
            Shoot shooterInstance = other.GetComponent<Shoot>();

            if (shooterInstance.damage - Life <= 0)
            {
                //Destroy Object
            }
            else
            {
                Life = Life - shooterInstance.damage;
                //Play damage animation
            }
        }
    }
}
