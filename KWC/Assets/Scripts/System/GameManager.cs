using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaeManager : MonoBehaviour
{
    public GameObject blockPrefab;

    private void Start()
    {

        StartCoroutine(CraeteBlockRoop());
    }


    private void Update()
    {
        Destroy(GameObject.Find(blockPrefab.name + ("Block")), 1f);
    }

    IEnumerator CraeteBlockRoop()
    {
        while (true)
        {
            CraeteBlock();
            yield return new WaitForSeconds(1);
        }

    }

    private void CraeteBlock()
    {
        Vector3 block = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        block.z = 0.0f;
        Instantiate(blockPrefab, block, Quaternion.identity);
    }
}
