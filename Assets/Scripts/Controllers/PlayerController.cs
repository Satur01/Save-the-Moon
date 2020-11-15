using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Animator animator;

    [SerializeField, Range(0, 100)]
    float speed = 0;

    float moveHorizontal, moveVertical;

    int velocityXHash;
    int velocityYHash;

    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        velocityXHash = Animator.StringToHash("Velocity X");
        velocityYHash = Animator.StringToHash("Velocity Y");
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat(velocityXHash, Input.GetAxis("Horizontal"));
        animator.SetFloat(velocityYHash, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        rigid2d.MovePosition((Vector2)transform.position + (new Vector2(moveHorizontal, moveVertical).normalized * speed * Time.deltaTime));
    }
}
