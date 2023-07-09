using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillWire : MonoBehaviour
{
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ErrCode"))
        {
            Destroy(collision.gameObject);
            Boss.curHp -= 10;
        }
    }
}
