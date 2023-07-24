using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDrill : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject UpWire;
    public GameObject DownWire;
    public GameObject Triangle;
    public GameObject Danger;
    public float DrillCool = 7f;
    public float coolTime;
    public float DangerCool = 5f;
    public float DangerCoolTime;
    [SerializeField]
    private float FirstCool;
    [SerializeField]
    private bool isCool;
    // Start is called before the first frame update
    void Start()
    {
        UpWire.SetActive(false);
        DownWire.SetActive(false);
        isCool = true;
        coolTime = DrillCool;
        DangerCoolTime = DangerCool;
    }

    // Update is called once per frame
    void Update()
    {
        FirstCool -= Time.deltaTime;
        if(FirstCool <= 0)
        {
            if (isCool && Boss.PhaseCount != 7 && Boss.PhaseCount != 4 && Boss.PhaseCount != 6)
            {
                coolTime -= Time.deltaTime;
                if (Boss.PhaseCount >= 3)
                {
                    DrillCool = 3;
                    DangerCoolTime = 1f;
                }
                if (coolTime <= 0)
                {
                    StartCoroutine("Move");
                    isCool = false;
                    coolTime = DrillCool;
                }
            }

            if (Boss.PhaseCount == 5)
            {
                UpWire.SetActive(true);
                DownWire.SetActive(true);
            }
            else
            {
                UpWire.SetActive(false);
                DownWire.SetActive(false);
            }
        }
        
    }

    IEnumerator Move()
    {
        Triangle.transform.position = new Vector2(34f, Random.Range(-16, 1.5f));
        Danger.transform.position = new Vector2(20f, Triangle.transform.position.y);


        yield return new WaitForSeconds(DangerCoolTime);
        Danger.transform.position = new Vector2(36f, Triangle.transform.position.y);
        Triangle.transform.DOMoveX(18.5f, 2);
        yield return new WaitForSeconds(3f);
        Triangle.transform.DOMoveX(34f, 2);

        isCool = true;
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 force = transform.right * -5;
            //rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
