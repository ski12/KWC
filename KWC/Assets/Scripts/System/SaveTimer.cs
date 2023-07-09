using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    public static SaveTimer instance;
    private void Awake()
    {
        instance = this;
    }
    public void SaveTime(float time)
    {
        PlayerPrefs.SetFloat("time",time);
    }
    public float LoadTime()
    {
        if (!PlayerPrefs.HasKey("time")) return 0;
        return PlayerPrefs.GetFloat("time");
    }
    
}
