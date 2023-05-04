using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField]
    private GameObject enemy, planBoss;
    // Start is called before the first frame update
    private BoxCollider2D box;
    private void Awake()
    {
        MakeInstances();
        box = GetComponent<BoxCollider2D>();
    }
    void MakeInstances()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartCoroutine(SpownerEnemy());
    }

    public IEnumerator SpownerEnemy()
    {

        if (Score.score1 % 10 == 0 && Score.score1 > 1)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            float minX = -box.bounds.size.x / 2f;
            float maxX = box.bounds.size.x / 2f;
            Vector3 tem = transform.position;
            tem.x = Random.Range(minX, maxX);
            Instantiate(planBoss, tem, Quaternion.identity);

        }
        else
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            float minX = -box.bounds.size.x / 2f;
            float maxX = box.bounds.size.x / 2f;
            Vector3 tem = transform.position;
            tem.x = Random.Range(minX, maxX);
            Instantiate(enemy, tem, Quaternion.identity);
            StartCoroutine(SpownerEnemy());
        }

    }
}
