using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startUI : MonoBehaviour
{
   public void OnClickStart()
    {
        SceneManager.LoadScene("InGame");

    }
}
