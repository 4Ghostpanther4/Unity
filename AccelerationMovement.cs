using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationMovement : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed = 5f;
    [SerializeField] float acceleration = 3f;
    [SerializeField] float brakeStrength = 7f;
    float speed;
    float moveInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new(speed, rb.velocity.y);
        PlayerMovement();
    }

    void PlayerMovement()
    {
        const float threshold = 0.01f;
        if (moveInput != 0)
        {
            speed += moveInput * (acceleration * Time.deltaTime);
        }
        else if (Mathf.Abs(speed) > threshold)
        {
            speed -= Mathf.Sign(speed) * brakeStrength * Time.deltaTime;
        }
        else
        {
            speed = 0f;
        }

        speed = Mathf.Clamp(speed, -maxMoveSpeed, maxMoveSpeed);
    }

}
