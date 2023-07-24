using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Destroybottom : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(DownGround),10f);
   
    }

    private void DownGround()
    {
        transform.DOMoveY(-23, 10);
        Destroy(gameObject,10f);
    }
}
