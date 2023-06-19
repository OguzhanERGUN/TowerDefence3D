using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab,transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
