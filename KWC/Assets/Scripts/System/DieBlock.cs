using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DieBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.DOMoveY(-22, 5f);
    }
}
