using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    [SerializeField]
    private float maxHp;

    [SerializeField]
    private float curHp;

    private Vector2 Midpos3;
    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos4;
    private Vector2 pos5;

    public GameObject Gimic;

    public static int PhaseCount = 1;

    private bool bossTeleport;

    public float height;
    private float telNumber;

    private void Awake()
    {
        bossTeleport = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Midpos3 = new Vector2(0, 0.74f);
        pos1 = new Vector2(-10, 2.54f);
        pos2 = new Vector2(10, 2.54f);
        pos4 = new Vector2(-10, -2.54f);
        pos5 = new Vector2(10, -2.54f);
        Gimic = GameObject.Find("EventSystem");

        hpbar.value = curHp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpbar.value = Mathf.Lerp(hpbar.value, curHp / maxHp, Time.deltaTime * 10);
        if (Input.GetKeyUp(KeyCode.K))
        {
            curHp -= 10;
        }

        if (curHp <= 80 && PhaseCount == 1)
        {
            phase2();
        }
        if (curHp <= 50 && PhaseCount == 2)
        {
            phase3();
        }
        if (curHp <= 30 && PhaseCount == 3)
        {
            phase4();
        }
        if (curHp <= 10 && PhaseCount == 4)
        {
            phase5();
        }

        if (PhaseCount == 4 && bossTeleport)
        {
            bossTeleport = false;
            StartCoroutine("TelStart");
        }
    }

    private void phase2()
    {
        Debug.Log("몰입");
        PhaseCount += 1;
    }

    private void phase3()
    {
        Debug.Log("경고");
        PhaseCount += 1;
    }

    private void phase4()
    {
        Debug.Log("폭주");
        bossTeleport = true;
        PhaseCount += 1;

    }

    private void phase5()
    {
        bossTeleport = false;
        transform.position = Midpos3;
        Debug.Log("제거");
        Gimic.GetComponent<Phase5Gimic>().Destro();
        PhaseCount += 1;
    }

    IEnumerator TelStart()
    {
        yield return new WaitForSeconds(5f);
        telNumber = Random.Range(1, 5 + 1);
        if (telNumber == 1)
            transform.position = pos1;
        if (telNumber == 2)
            transform.position = pos2;
        if (telNumber == 3)
            transform.position = Midpos3;
        if (telNumber == 4)
            transform.position = pos4;
        if (telNumber == 5)
            transform.position = pos5;
        bossTeleport = true;
        yield return null;
    }




}
