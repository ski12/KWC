using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacinSpawn : MonoBehaviour
{
    public GameObject Vacinspawn;
    // Start is called before the first frame update
    private float DestroyTime = 15f;
    [SerializeField]
    private float RoopCooldown;

    private void Start()
    {

    }


    private void Update()
    {
        if (Boss.PhaseCount == 5)
        {
            if (RoopCooldown <= 0)
            {
                StartCoroutine(CraeteBlockRoop());
                RoopCooldown = 6;
            }
            RoopCooldown -= Time.deltaTime;
        }


    }

    IEnumerator CraeteBlockRoop()
    {
        yield return new WaitForSeconds(3f);
        CraeteBlock();



    }


    private void CraeteBlock()
    {
        Vector3 blockPosition = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        blockPosition.z = 0.0f;
        GameObject block = Instantiate(Vacinspawn, blockPosition, Quaternion.identity);
        Destroy(block, DestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
