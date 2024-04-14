using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public LayerMask groundLayer;
    public AudioSource jump;
    Animator animator;
    bool isGrounded;
    bool hasJumped;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !hasJumped)
        {
            Jump();
            hasJumped = true;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(moveInput * runSpeed * Time.deltaTime, 0));
        animator.SetFloat("xSpeed", Mathf.Abs(moveInput * runSpeed));
        animator.SetBool("isGrounded", isGrounded);
    }

    void Jump()
    {
        jump.Play();    
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        animator.Play("JUMP");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }
}
