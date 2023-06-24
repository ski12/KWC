using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float jumpPower;
    public float speed = 10;
    private Rigidbody2D rb;
    public bool isGround = false;
    public bool isDash;
    private float defaultSpeed;
    public float dashSpeed;
    public float defaultTime;
    private float dashTime;
    

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

            if (!isDash) 
            {
                isDash = true;
                rb.velocity = Vector2.down * dashSpeed;
            }

        }
        else
        {
            isDash = false;
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
        if (!isDash)
        {
            float x = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(x * defaultSpeed, rb.velocity.y);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == ("ground"))
        {
            isGround = false;
        }
    }
    

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpPower;
        
    }

    
}
