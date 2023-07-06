using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DotweenBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        transform.DOMoveY(-22, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "phase5gp")
        {
            Destroy(gameObject);
        }
    }




}
