using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndTimer : MonoBehaviour
{
    public Text timerText;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = SaveTimer.instance.LoadTime();
        timerText.text = "�÷��� Ÿ�� : " + time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
