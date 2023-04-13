using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public static void ApplyKnockback(Rigidbody2D rb, float knockbackForce, Vector2 direction)
    {
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }
}
