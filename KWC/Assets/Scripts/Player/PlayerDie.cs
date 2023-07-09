using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerDie : MonoBehaviour
{
    public Timer m_tiemr;
    private GameManager Gm;
    private void LoadScene()
    {
        Gm.GameEnd();
    }
    private void Start()
    {
        Gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == ("SlowFlat"))
        {
            Invoke(nameof(LoadScene), 0.1f);
            SaveTimer.instance.SaveTime(m_tiemr.timer);
            
        }
        /*if(collision.gameObject.tag == ("Drill"))
        {
            SceneManager.LoadScene("End");
        }*/
    }
}
