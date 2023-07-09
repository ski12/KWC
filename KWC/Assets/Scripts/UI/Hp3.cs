using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp3 : MonoBehaviour
{
    Image Php3;
    public Sprite Dead;
    // Start is called before the first frame update
    void Start()
    {
        Php3 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.playerCurhp <= 2)
        {
            Php3.sprite = Dead;
        }
    }
}
