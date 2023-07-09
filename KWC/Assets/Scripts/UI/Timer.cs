using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = formattedTime;
    }
}
