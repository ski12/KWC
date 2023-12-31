using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static bool IsInv;
    public float InvTime = 1.5f;
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
        IsInv = false;
        
    }

    private void FixedUpdate()
    {
        if(playerCurhp <= 0)
        {
            Destroy(gameObject);
        }
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
        if (rb.velocity.y < -0.1 && anim.GetBool("IsJump"))
        {
            
            anim.SetBool("IsFalling", true);
        }
        else
        {
            anim.SetBool("IsFalling", false);
        }

    }
    
    void Update()
    {
        if(playerCurhp <= 0)
        {
            SceneManager.LoadScene("End");
        }

        if (IsInv)
        {
            InvTime -= Time.deltaTime;
            if(InvTime <= 0)
            {
                IsInv = false;
            }
        }
        else
        {
            InvTime = 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Boss.curHp -= 5;
        }
        if(isGround == false)
        {
            anim.SetBool("IsRun", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            
            isGround = false;
            anim.SetBool("onground", false);
            rb.velocity = Vector2.up * jumpPower;
            
        }
        if(isGround == false)
        {
            anim.SetBool("IsJump", true);
            anim.SetBool("onground", false);
        }
        if(isGround == true)
        {
            anim.SetBool("onground", true);
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
        else if(Physics2D.Raycast(transform.position + new Vector3(0.6f, -0.8f, 0), transform.up, -1, GroundCheck))
        {
            defaultSpeed = speed;
            isGround = true;
        }
        else if(Physics2D.Raycast(transform.position + new Vector3(-0.8f, -0.8f, 0), transform.up, -1, GroundCheck))
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
        Gizmos.DrawRay(transform.position + new Vector3(.4f, -0.8f, 0), transform.up * -1);
        Gizmos.DrawRay(transform.position + new Vector3(-.6f, -0.8f, 0), transform.up * -1);
        Gizmos.DrawWireCube(pos.position, boxSize);
        Gizmos.DrawWireCube(Rpos.position, RboxSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Destroyer"))
        {
            playerCurhp = 0;
        }
        if (collision.collider.CompareTag("SlowFlat"))
        {
            playerCurhp = 0;
        }
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
                if (Boss.PhaseCount == 7)
                {
                    if (collider.tag == "Boss")
                    {
                        Boss.curHp -= 2f;

                    }
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
                if(Boss.PhaseCount == 7)
                {
                    if (collider.tag == "Boss")
                    {
                        Boss.curHp -= 2f;

                    }
                }
               
            }
        }





    }

   



}
