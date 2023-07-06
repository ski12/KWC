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
    private bool isRun;
    private float defaultSpeed;
    public float dashSpeed;
    public float dashTime;
    private float x;
    private Animator anim;

    SpriteRenderer Spr;

    [SerializeField]
    private LayerMask GroundCheck;

    void Start()
    {
        Spr= GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        isRun = false;
    }

    private void FixedUpdate()
    {
        if (isDash == false)
        {
            x = Input.GetAxisRaw("Horizontal");
            
        }
        rb.velocity = new Vector2(x * defaultSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.D))
        {
            Spr.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Spr.flipX = true;
        }
        if (rb.velocity.x != 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround= false;
            rb.velocity = Vector2.up * jumpPower;
          

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

        if (Physics2D.Raycast(transform.position + new Vector3(0, -0.8f, 0), transform.up, -1, GroundCheck))
        {
            defaultSpeed = speed;
            isGround = true;
        }
        else
        {
            isGround= false;
        }

    }

    IEnumerator DashEnd()
    {
        yield return new WaitForSeconds(dashTime);
        defaultSpeed = speed;
        isDash = false;
    }

    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + new Vector3(0, -0.8f, 0), transform.up * -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FiredBottle"))
        {
            Destroy(collision.gameObject);
        }
    }





}
