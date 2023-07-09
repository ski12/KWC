using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrillWire : MonoBehaviour
{
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("VacinCode"))
        {
            Destroy(collision.gameObject);
            Boss.curHp -= 20;
            transform.DOMoveX(-15.4f, 3);
            Destroy(gameObject);
        }
    }
}
