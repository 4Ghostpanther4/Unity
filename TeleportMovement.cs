using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMovement : MonoBehaviour
{
    readonly float speed = 5f;
    float moveInput;

    readonly float jumpForce = 7.5f;

    Rigidbody2D rb;

    public bool hasTeleported;
    public bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new(moveInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(TeleportExit());
    }

    IEnumerator TeleportExit()
    {
        yield return new WaitForSeconds(.1f);
        hasTeleported = false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}