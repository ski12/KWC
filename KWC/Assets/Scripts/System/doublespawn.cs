using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublespawn : MonoBehaviour
{
    public GameObject blockPrefab;
    private float DestroyTime = 15f;


    private void Start()
    {
        StartCoroutine(CraeteBlockRoop());
    }


    private void Update()
    {

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
        Vector3 blockPosition = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        blockPosition.z = 0.0f;
        GameObject block = Instantiate(blockPrefab, blockPosition, Quaternion.identity);
        Destroy(block, DestroyTime);
    }
}
