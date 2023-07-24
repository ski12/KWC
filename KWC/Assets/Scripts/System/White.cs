using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : MonoBehaviour
{
    public Material m_white;
    public Material M_default;
    SpriteRenderer spr;
    private float whiteTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (whiteTime > 0)
        {
            spr.material = m_white;
            whiteTime -= Time.deltaTime;
        }
        else
        {
            spr.material = M_default;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        whiteTime = 1f;
    }

}
