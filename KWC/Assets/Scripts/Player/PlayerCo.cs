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
        // �÷��̾ �������� ���� ���
        if (spriteRenderer.flipX == true)
        {
            playerHand.localPosition = new Vector3(1f, 0f, 0f);
        }
        // �÷��̾ ������ ���� ���
        else
        {
            playerHand.localPosition = new Vector3(-1f, 0f, 0f);
        }
    }
}
