using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDrill : MonoBehaviour
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
        if (Boss.PhaseCount == 3)
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
        }



    }

    IEnumerator Move()
    {
        Triangle.transform.position = new Vector2(Random.Range(-21.5f, 21.5f), 9);

        Danger.transform.position = new Vector2(Triangle.transform.position.x, 1f);
        yield return new WaitForSeconds(DangerCoolTime);
        Danger.transform.position = new Vector2(Triangle.transform.position.x, 9);
        Triangle.transform.DOMoveY(0f, 2);
        yield return new WaitForSeconds(3f);
        Triangle.transform.DOMoveY(9f, 2);

        isCool = true;
        yield return null;
    }

}
