using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp5 : MonoBehaviour
{
    Image Php5;
    public Sprite Dead;
    // Start is called before the first frame update
    void Start()
    {
        Php5 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.playerCurhp <= 4)
        {
            Php5.sprite = Dead;
        }
    }
}
