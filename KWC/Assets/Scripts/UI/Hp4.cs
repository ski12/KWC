using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp4 : MonoBehaviour
{
    Image Php4;
    public Sprite Dead;
    // Start is called before the first frame update
    void Start()
    {
        Php4 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.playerCurhp <= 3)
        {
            Php4.sprite = Dead;
        }
    }
}
