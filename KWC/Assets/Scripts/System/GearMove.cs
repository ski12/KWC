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

    private Vector2 UpGearSpawn1;
    private Vector2 UpGearSpawn2;
    private Vector2 DownGearSpawn1;
    private Vector2 DownGearSpawn2;
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

    IEnumerator GearGimicStart()
    {
        GearPositionNum = Random.Range(1, 2 + 1);
        if(GearPositionNum == 1)
        {
            transform.position = new Vector2(-9.4f, -14f);
        }
        else
        {
            transform.position = new Vector2(9.7f, -1f);
        }
        yield return new WaitForSeconds(3f);
        if(GearPositionNum == 1)
        {
            UpGear.transform.position = UpGearSpawn1;
            
            UpGear.transform.DOMoveX(24, 5f);
            
        }
        if (GearPositionNum == 2)
        {
            
            DownGear.transform.position = DownGearSpawn2;
            
            DownGear.transform.DOMoveX(-24, 6f);
        }
        yield return null;
    }
}
