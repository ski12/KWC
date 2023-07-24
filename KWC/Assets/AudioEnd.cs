using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnd : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.playerCurhp <= 0)
        {
            audioSource.Stop();
        }
    }
}
