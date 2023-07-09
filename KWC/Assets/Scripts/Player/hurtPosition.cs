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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Physics2D.Raycast(transform.position + new Vector3(0, 1f, 0), transform.up, 1, drillMask))
        {
            PlayerMove.playerCurhp -= 1;
        }
        if (Physics2D.Raycast(transform.position + new Vector3(0, 1f, 0), transform.up, 1, FallingMask))
        {
            PlayerMove.playerCurhp -= 1;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "die")
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
