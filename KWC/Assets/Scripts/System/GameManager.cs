using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Boss boss;
    private float BossHp;
    public Text text;
    private void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }
    public void GameEnd()
    {

        BossHp = Boss.curHp;
        SceneManager.LoadScene("End");
        
        Invoke("EndScene", 1f);
       
    }
    private void EndScene()
    {
        
        text = GameObject.FindWithTag("ClearText").GetComponent<Text>();
        if(BossHp <= 0)
        {
            text.text = "Clear!";
        }
        else
        {
            text.text = ("보스 HP : " + BossHp);
        }
      
        
    }
}
