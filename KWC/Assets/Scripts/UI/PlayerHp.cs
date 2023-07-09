using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    Image Hp1;
    public Sprite Dead;
    // Start is called before the first frame update
    void Start()
    {
        Hp1= GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.playerCurhp<=0)
        {
            Hp1.sprite = Dead;
        }
    }
}
