
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Phase5Gimic : MonoBehaviour
{
    public GameObject Left_destroyer;
    public GameObject Right_destroyer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Destro()
    {
        Right_destroyer.transform.DOMoveX(7.9f, 50f);
        Left_destroyer.transform.DOMoveX(-7.9f, 50f);
    }
}
