using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizantal;
    private float Speed = 8f;
    private bool isFacingTheRightWay = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizantal = Input.GetAxis("Horizontal");
        flip();
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizantal * Speed, rb.velocity.y);
    }
    private void flip()
    {
        if(isFacingTheRightWay && horizantal < 0f || isFacingTheRightWay && horizantal > 0f)
        {
            isFacingTheRightWay = !isFacingTheRightWay;
            Vector3 localScale = transform.localScale;
            localScale.x *=  -1f;
            transform.localScale = localScale;
        }
    }
}
