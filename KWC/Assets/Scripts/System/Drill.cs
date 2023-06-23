using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drill : MonoBehaviour
{
    public GameObject Triangle;
    public GameObject Danger;
    public float coolTime = 7f;
    [SerializeField]
    private bool isCool;
    // Start is called before the first frame update
    void Start()
    {
        isCool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCool)
        {
            coolTime -= Time.deltaTime;
            if (coolTime <= 0)
            {
                StartCoroutine("Move");
                isCool = false;
                coolTime = 7f;
            }
        }


    }

    IEnumerator Move()
    {
        Triangle.transform.position = new Vector2(-30, Random.Range(-4, 4));
        Danger.transform.position = new Vector2(-22, Triangle.transform.position.y);


        yield return new WaitForSeconds(5f);
        Danger.transform.position = new Vector2(-30, Triangle.transform.position.y);
        Triangle.transform.DOMoveX(-22, 2);
        yield return new WaitForSeconds(3f);
        Triangle.transform.DOMoveX(-30, 2);

        isCool = true;
        yield return null;
    }


}
