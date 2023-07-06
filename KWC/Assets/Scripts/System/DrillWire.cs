using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillWire : MonoBehaviour
{
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Boss.curHp -= 5;
        }
    }
}
