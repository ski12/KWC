using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class DotweenBlock : MonoBehaviour
{
    Rigidbody2D EnemyRb;
    public bool Attackboss;
    public float speed = 70;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb= GetComponent<Rigidbody2D>();
        Attackboss = false;
       
    }

    private void FixedUpdate()
    {
        EnemyRb.velocity = new Vector2(0, -speed * Time.deltaTime);
    }
    private void Awake()
    {
        //transform.DOMoveY(-22, 10f).SetEase(Ease.Unset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "phase5gp")
        {
            Destroy(gameObject);
        }
        if(Boss.PhaseCount !=4 || Boss.PhaseCount != 5 || Boss.PhaseCount != 6)
        {
            if (collision.tag == "Boss" && Attackboss)
            {
                Destroy(gameObject);
                Boss.curHp -= 10;
            }
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SlowFlat"))
        {
            transform.gameObject.layer = 9;
            speed = speed / 10;
            EnemyRb.mass = 2000;
        }
        if (collision.collider.CompareTag("Drill"))
        {
            Destroy(gameObject);
        }

    }

    public void Left()
    {
       
        transform.DOMoveX(transform.position.x - 7,1f);
        Attackboss= true;
        StartCoroutine("AttackvossTime");
    }
    public void Right()
    {

        transform.DOMoveX(transform.position.x + 7, 1f);
        Attackboss= true;
        StartCoroutine("AttackvossTime");
    }

    IEnumerator AttackvossTime()
    {
        yield return new WaitForSeconds(1.5f);
        Attackboss = false;
    }




}
