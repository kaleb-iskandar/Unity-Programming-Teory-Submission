using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float xRange = 3.5f,
        startDelay = 2f,
        spawnDelay = 1f;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), startDelay, spawnDelay);
    }
    void SpawnEnemy()
    {
        int randomIndx = Random.Range(0, enemyPrefabs.Length);        
        Instantiate(enemyPrefabs[randomIndx],new Vector3(Random.Range(-xRange,xRange),10,0),transform.rotation);
    }
}
