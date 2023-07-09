using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameExit()
    {
        SceneManager.LoadScene("Start");
    }
    public void GameReStart()
    {
        SceneManager.LoadScene("ChapterSelect");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("ChapterSelect");
    }

    public void GameClose()
    {
        Application.Quit();
    }

    public void FIrstChapter()
    {
        SceneManager.LoadScene("InGame");
    }
}
