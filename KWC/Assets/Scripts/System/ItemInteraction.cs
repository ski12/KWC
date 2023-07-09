using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public float throwForce = 10f; // 아이템을 던질 힘의 크기
    public float throwAngle = 45f; // 아이템을 던질 각도

    private bool isHeld = false;
    private Transform playerHand;
    private Rigidbody2D rb;
    private SpriteRenderer PlayerSr; 
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.gravityScale = 0f; // 중력 비활성화
        
        playerHand = GameObject.Find("PlayerHand").transform;
        PlayerSr = playerHand.parent.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isHeld)
        {
            HoldItem();
        }
    }

    private void Update()
    {
        if (isHeld && Input.GetKeyDown(KeyCode.K))
        {
            ThrowItem();
        }

        if (isHeld)
        {
            UpdateItemPosition();
        }
    }

    private void HoldItem()
    {
        isHeld = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        transform.SetParent(playerHand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    private void ThrowItem()
    {
        isHeld = false;
        transform.SetParent(null);

        Vector2 throwDirection = Quaternion.Euler(0f, 0f, throwAngle) * playerHand.up;
        Vector2 throwVelocity = throwDirection.normalized * throwForce;

        throwVelocity = new Vector2(PlayerSr.flipX ? -throwVelocity.x : throwVelocity.x, throwVelocity.y);

        rb.velocity = throwVelocity;
        rb.gravityScale = 1f;
    }

    private void UpdateItemPosition()
    {
        transform.position = playerHand.position;
    }
}



