using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPosition : MonoBehaviour
{
    public LayerMask drillMask;
    public LayerMask FallingMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block")&& !PlayerMove.IsInv)
        {
            PlayerMove.playerCurhp -= 1;
            PlayerMove.IsInv = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Drill" && !PlayerMove.IsInv)
        {
            PlayerMove.playerCurhp -= 1;
            PlayerMove.IsInv = true;
        }
        if (Physics2D.Raycast(transform.position + new Vector3(0, 1f, 0), transform.up, 1, FallingMask) && !PlayerMove.IsInv)
        {
            PlayerMove.playerCurhp -= 1;
            PlayerMove.IsInv = true;
            Destroy(collision.gameObject);
        }
        if(collision.collider.CompareTag("die"))
        {
            PlayerMove.playerCurhp = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + new Vector3(0, 1f, 0), transform.up * 1);
    }
}
