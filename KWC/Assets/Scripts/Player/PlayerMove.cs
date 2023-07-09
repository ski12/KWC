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
    public RaycastHit hit;
    public Rigidbody2D Enrb;
    public float playerMaxhp;
    public static float playerCurhp;

    SpriteRenderer Spr;
    public Vector2 boxSize;
    public Transform pos;
    public Vector2 RboxSize;
    public Transform Rpos;

    [SerializeField]
    private LayerMask GroundCheck;


    void Start()
    {
        Spr= GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        isRun = false;
        playerCurhp = playerMaxhp;
        
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
            
            Spr.flipX = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Spr.flipX = false;
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
        
        if(isGround == false)
        {
            anim.SetBool("IsRun", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            
            isGround = false;
            rb.velocity = Vector2.up * jumpPower;
            
        }
        if(isGround == false)
        {
            anim.SetBool("IsJump", true);
        }
        if(isGround == true)
        {
            anim.SetBool("IsJump", false);
        }
        
        if(Input.GetKeyDown(KeyCode.P) && defaultSpeed != 0 && !isDash)
        {
            
            defaultSpeed = dashSpeed;
            isDash = true;
            StartCoroutine(DashEnd());
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            
            defaultSpeed = 0;
            rb.velocity = Vector2.down * dashSpeed;
            

        }

        if (Physics2D.Raycast(transform.position + new Vector3(0, -0.8f, 0), transform.up, -1, GroundCheck))
        {
            defaultSpeed = speed;
            isGround = true;
        }
        else if(Physics2D.Raycast(transform.position + new Vector3(0.4f, -0.8f, 0), transform.up, -1, GroundCheck))
        {
            defaultSpeed = speed;
            isGround = true;
        }
        else if(Physics2D.Raycast(transform.position + new Vector3(-0.4f, -0.8f, 0), transform.up, -1, GroundCheck))
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
        Gizmos.DrawRay(transform.position + new Vector3(0.4f, -0.8f, 0), transform.up * -1);
        Gizmos.DrawRay(transform.position + new Vector3(-0.4f, -0.8f, 0), transform.up * -1);
        Gizmos.DrawWireCube(pos.position, boxSize);
        Gizmos.DrawWireCube(Rpos.position, RboxSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FiredBottle"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void PlayerAttack()
    {
       if(Spr.flipX == false)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Block")
                {
                    //Destroy(collider.gameObject);
                    collider.transform.GetComponent<DotweenBlock>().Left();
           
                }
            }
        }
        if (Spr.flipX == true)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Rpos.position, RboxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Block")
                {
                  
                    collider.transform.GetComponent<DotweenBlock>().Right();
                }
            }
        }





    }

   



}
