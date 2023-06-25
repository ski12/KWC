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
    public float dashTime;
    private float x;
    

    void Start()
    {
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        if (isDash == false)
        {
            x = Input.GetAxisRaw("Horizontal");
            
        }
        rb.velocity = new Vector2(x * defaultSpeed, rb.velocity.y);
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isGround)
        {
            isGround = true;
            Jump();
            
        }
        if(Input.GetKeyDown(KeyCode.P) && defaultSpeed != 0 && !isDash)
        {
            defaultSpeed = dashSpeed;
            isDash = true;
            StartCoroutine(DashEnd());
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            
            defaultSpeed = 0;
            rb.velocity = Vector2.down * dashSpeed;
            

        }


        
    }

    IEnumerator DashEnd()
    {
        yield return new WaitForSeconds(dashTime);
        defaultSpeed = speed;
        isDash = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == ("ground"))
        {
            defaultSpeed = speed;
            isGround = false;
        }
        if(other.gameObject.tag == ("ang"))
        {
            isGround = false;
        }
        if (other.gameObject.tag == ("die"))
        {
            Debug.Log("dddd");
            Destroy(gameObject);
        }
    }

    

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpPower;
        
    }

    
}
