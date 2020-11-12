using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 shootDirection;
    float shootSpeed;

    Rigidbody2D rgb2d;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 10)
        {
            this.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rgb2d.MovePosition((Vector2) transform.position + shootDirection * shootSpeed * Time.deltaTime);
    }

    public void SetBulletStats(Vector2 ShootDirection, float ShootSpeed)
    {
        shootDirection = ShootDirection;
        shootSpeed = ShootSpeed;
    }
}
