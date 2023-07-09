using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCo : MonoBehaviour
{
    public Transform playerHand;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 플레이어가 오른쪽을 보는 경우
        if (spriteRenderer.flipX == true)
        {
            playerHand.localPosition = new Vector3(1f, 0f, 0f);
        }
        // 플레이어가 왼쪽을 보는 경우
        else
        {
            playerHand.localPosition = new Vector3(-1f, 0f, 0f);
        }
    }
}
