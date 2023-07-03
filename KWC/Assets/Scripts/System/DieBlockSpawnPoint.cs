using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DieBlockSpawnPoint : MonoBehaviour
{
    public GameObject DieBlockPrefab;
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
            yield return new WaitForSeconds(5);
        }

    }


    private void CraeteBlock()
    {
        Vector3 DieBlockPosition = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 0.5f), 1.1f, 0));
        DieBlockPosition.z = 0.0f;
        GameObject block = Instantiate(DieBlockPrefab, DieBlockPosition, Quaternion.identity);
        Destroy(block, DestroyTime);
    }

}
