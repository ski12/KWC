using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float jumpPower;
    public float speed;
    private Rigidbody2D rb;
    public bool isGround = false;
    public bool isDash = false;
    private float defaultSpeed;
    public float dashSpeed;
    public float defaultTime;
    private float dashTime;
    private int dashCount = 0;
    private float lastDashTime;

    void Start()
    {
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * defaultSpeed, rb.velocity.y);

        
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isGround)
        {
            isGround = true;
            Jump();
            
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
            
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            isDash = true;
            
            rb.velocity = Vector2.down * dashSpeed;
        }
        
        if (dashTime <= 0)
        {
            defaultSpeed = speed;
            if (isDash)
            {
                dashTime = defaultTime;
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
            defaultSpeed = dashSpeed;
        }
        
        isDash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("ground"))
        {
            isGround = false;
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpPower;
        
    }

    
}
