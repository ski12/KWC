using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GearMove : MonoBehaviour
{
    [SerializeField]
    private GameObject UpGear;
    [SerializeField]
    private GameObject DownGear;

    [SerializeField]
    private float GearCoolTime;

    [SerializeField]
    private int GearPositionNum;
    [SerializeField]
    private bool position1 = false;
    


    private Vector2 UpGearSpawn1;
    private Vector2 UpGearSpawn2;
    private Vector2 DownGearSpawn1;
    private Vector2 DownGearSpawn2;
    [SerializeField]
    private GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        UpGearSpawn1 = new Vector2(-20f, 3.4f); //왼쪽
        UpGearSpawn2 = new Vector2(13.5f, 3.5f);  // 오른쪽
        DownGearSpawn1 = new Vector2(-13.5f, -18f);
        DownGearSpawn2 = new Vector2(19.66f, -18f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.PhaseCount== 4)
        {
            if (Boss.PhaseCount == 4 && GearCoolTime <= 0)
            {
                StartCoroutine("GearGimicStart");
                GearCoolTime = 13;
            }
            GearCoolTime -= Time.deltaTime;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ErrCode") && Boss.PhaseCount == 4)
        {
            Destroy(collision.gameObject);
            if (position1)
            {
                Instantiate(Effect, transform.position, Quaternion.identity);
                transform.position = new Vector2(14.6f, -0.4f);
            }
            if (!position1)
            {
                Instantiate(Effect, transform.position, Quaternion.identity);
                transform.position = new Vector2(-14.6f, -12.2f);
            }
        }
    }

    IEnumerator GearGimicStart()
    {
        GearPositionNum = Random.Range(1, 2 + 1);
        if(GearPositionNum == 1)
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
            transform.position = new Vector2(-14.6f, -12.2f);
            position1 = true;
        }
        else
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
            transform.position = new Vector2(14.6f, 0.4f);
            position1= false;
        }
        yield return new WaitForSeconds(3f);
        if(GearPositionNum == 1)
        {
            UpGear.transform.position = UpGearSpawn1;
            
            UpGear.transform.DOMoveX(26, 5f);
            
        }
        if (GearPositionNum == 2)
        {
            
            DownGear.transform.position = DownGearSpawn2;
            
            DownGear.transform.DOMoveX(-26, 6f);
        }
        yield return null;
    }
}
