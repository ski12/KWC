using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;


    public GameObject FiredBottle;

    [SerializeField] 
    private float phase6Time;

    [SerializeField]
    private GameObject tp1;
    [SerializeField] 
    private GameObject tp2;

    [SerializeField]
    private float maxHp;

    [SerializeField]
    private float curHp;

    private Vector2 Midpos3;
    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos4;
    private Vector2 pos5;
    private Vector2 TpPos1;
    private Vector2 TpPos2;

    public GameObject Gimic;

    public static int PhaseCount = 1;
    [SerializeField]
    private bool bossTeleport;



    public float height;
    private float telNumber;
    [SerializeField]
    private float Tp;

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
        TpPos1 = new Vector2(-8.67f, -7.3f);
        TpPos2 = new Vector2(8.67f, -7.3f);
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
            curHp -= 5;
        }

        if (curHp <= 80 && PhaseCount == 1)
        {
            phase2();
        }
        if (curHp <= 60 && PhaseCount == 2)
        {
            phase3();
        }
        if (curHp <= 40 && PhaseCount == 3)
        {
            phase34();
        }
        if (curHp <= 30 && PhaseCount == 4)
        {
            phase4();
        }
        if (curHp <= 20 && PhaseCount == 5)
        {
            phase5();
        }
        if (curHp <= 10 && PhaseCount == 5)
        {
            phase6();
        }

        if (PhaseCount == 5 && bossTeleport)
        {
            bossTeleport = false;
            StartCoroutine("TelStart");
        }
        if(PhaseCount == 6 )
        {
            phase6Time -= Time.deltaTime;
            bossTeleport = false;
            if(phase6Time <= 0)
            {
                phase6Time = 30f;
                StartCoroutine("Wait10Sec");
                StartCoroutine("Tel");
                
            }
           
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

    private void phase34()   //페이즈 34 는 count == 4
    {
        Debug.Log("흥분");
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
        
        Debug.Log("광폭");
        PhaseCount += 1;
       
    }

    private void phase6()
    {
        transform.position = Midpos3;
        Debug.Log("제거");
        Gimic.GetComponent<Phase5Gimic>().Destro();
        PhaseCount += 1;
    }

    IEnumerator TelStart()
    {
        yield return new WaitForSeconds(5f);
        telNumber = Random.Range(1, 5 + 1);
        if(PhaseCount == 5)
        {
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
        }
       
        yield return null;
    }

    IEnumerator Wait10Sec()
    {
        yield return new WaitForSeconds(10f);
    }

    IEnumerator Tel()
    {
        Tp = Random.Range(1, 2 + 1);
        if (Tp == 1)
            transform.position = TpPos1;
        if (Tp == 2)
            transform.position = TpPos2;
        yield return new WaitForSeconds(1.5f);
        if(Tp == 1)
        {
            tp2.transform.DOMoveX(12f, 1);
            yield return new WaitForSeconds(5f);
            tp2.transform.DOMoveX(32f, 1);
            Instantiate(FiredBottle, new Vector2(8.75f, 3), Quaternion.identity);
        }
        if (Tp == 2)
        {
            tp1.transform.DOMoveX(-12f, 1);
            yield return new WaitForSeconds(5f);
            tp1.transform.DOMoveX(-32f, 1);
            Instantiate(FiredBottle, new Vector2(-8.75f, 3), Quaternion.identity);
        }
        yield return new WaitForSeconds(7.5f);
        if (Tp == 1)
        {
            transform.position = TpPos2;
            yield return new WaitForSeconds(1.5f);
            tp1.transform.DOMoveX(-12f, 1);
            yield return new WaitForSeconds(5f);
            tp1.transform.DOMoveX(-32f, 1);
            Instantiate(FiredBottle, new Vector2(-8.75f, 3), Quaternion.identity);
        }
        if (Tp == 2)
        {
            transform.position = TpPos1;
            yield return new WaitForSeconds(1.5f);
            tp2.transform.DOMoveX(12f, 1);
            yield return new WaitForSeconds(5f);
            tp2.transform.DOMoveX(32f, 1);
            Instantiate(FiredBottle, new Vector2(8.75f, 3), Quaternion.identity);
        }
        yield return new WaitForSeconds(7.5f);

    }




}
