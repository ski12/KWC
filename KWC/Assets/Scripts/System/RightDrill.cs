using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDrill : MonoBehaviour
{
    public GameObject UpWire;
    public GameObject DownWire;
    public GameObject Triangle;
    public GameObject Danger;
    public float DrillCool = 7f;
    public float coolTime;
    public float DangerCool = 5f;
    public float DangerCoolTime;
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
        if (isCool && Boss.PhaseCount != 7)
        {
            coolTime -= Time.deltaTime;
            if (Boss.PhaseCount == 4)
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

        if(Boss.PhaseCount == 5)
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

    IEnumerator Move()
    {
        Triangle.transform.position = new Vector2(29.5f, Random.Range(-16, 1.5f));
        Danger.transform.position = new Vector2(21.5f, Triangle.transform.position.y);


        yield return new WaitForSeconds(DangerCoolTime);
        Danger.transform.position = new Vector2(29.5f, Triangle.transform.position.y);
        Triangle.transform.DOMoveX(19.5f, 2);
        yield return new WaitForSeconds(3f);
        Triangle.transform.DOMoveX(29.5f, 2);

        isCool = true;
        yield return null;
    }
}
