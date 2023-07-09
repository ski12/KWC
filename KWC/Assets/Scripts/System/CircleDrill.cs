using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.PhaseCount > 4)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Boss")
        {
            Boss.curHp -= 10;
        }
    }
}
