using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2d;
    [SerializeField, Range(0, 100)]
    float speed = 0;
    float moveHorizontal;
    float moveVertical;

    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rigid2d.MovePosition((Vector2)transform.position + (new Vector2(moveHorizontal, moveVertical).normalized * speed * Time.deltaTime));
    }
}
