using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp2 : MonoBehaviour
{
    Image Php2;
    public Sprite Dead;
    // Start is called before the first frame update
    void Start()
    {
        Php2 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.playerCurhp <= 1)
        {
            Php2.sprite = Dead;
        }
    }
}
