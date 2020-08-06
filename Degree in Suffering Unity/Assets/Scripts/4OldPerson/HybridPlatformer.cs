using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HybridPlatformer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private int extraJumps;
    public int extraJumpValue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //Flipping Y axis for facing left vs right
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //Double Jump
        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        //simply just to jump
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if(isGrounded == false && Input.GetKeyDown(KeyCode.Space))
        {
            if(extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                jumpTimeCounter = jumpTime;
                extraJumps--;
            }
        }

        //this is how to you measure the jump
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        //prevent infinite jump
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
