using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Vector2 ShootDirection;
    public float CreationRate;

    [Range(1, 100)]
    public float ShootSpeed = 10;

    GameObject bullet;
    float time;

    void Start()
    {
        time = Time.time + CreationRate;
    }

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            bullet = ObjectPool.SharedInstance.GetPooledObject();

            if (bullet != null && Time.time > time)
            {
                bullet.transform.position = this.transform.position;
                
                bullet.GetComponent<Bullet>().SetBulletStats(ShootDirection, ShootSpeed);
                bullet.SetActive(true);                            
                time = Time.time + CreationRate;
            }
        }


    }
}
