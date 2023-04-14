using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

// ReSharper disable once CheckNamespace
public class InputPlayer : MonoBehaviour
{

    [Header("Components")] public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Movement Values")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingForce = 16f;

    private float horizontal;
    private bool isFacingRight = true;
    private float inputX;
    private bool isGrounded;
    

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }

        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        isGrounded = isGroundedDef();
    }

   /* public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }
    }*/

    private bool isGroundedDef()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        var transform1 = transform;
        Vector3 localScale = transform1.localScale;
        localScale.x *= -1f;
        transform1.localScale = localScale;
    }
    
    /*public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }*/
    
    
}


