using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodJump : MonoBehaviour
{
    private Rigidbody2D RB;

    [SerializeField] private float mFallMultiplier;
    [SerializeField] private float mLowJumpMultiplier;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (RB.velocity.y < 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (mFallMultiplier - 1) * Time.deltaTime;
        }
        else if (RB.velocity.y > 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (mLowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
