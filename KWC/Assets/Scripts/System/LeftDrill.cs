using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeftDrill : MonoBehaviour
{
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


    }

    IEnumerator Move()
    {
        Triangle.transform.position = new Vector2(-35f, Random.Range(-16, 1.5f));
        Danger.transform.position = new Vector2(-22f, Triangle.transform.position.y);


        yield return new WaitForSeconds(DangerCoolTime);
        Danger.transform.position = new Vector2(-37f, Triangle.transform.position.y);
        Triangle.transform.DOMoveX(-18f, 2);
        yield return new WaitForSeconds(3f);
        Triangle.transform.DOMoveX(-35f, 2);

        isCool = true;
        yield return null;
    }



}
