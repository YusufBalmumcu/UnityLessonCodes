using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanagerscript : MonoBehaviour
{
    [SerializeField]
    GameObject enemyprefab;

    [SerializeField]
    GameObject enemycontainer;

    [SerializeField]
    GameObject[] BonusPrefabs;
    bool stopspawning = true;

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(TripleShotRoutine());
    }

    public void OnPlayerDeath()
    {
        stopspawning = true;
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (stopspawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-7.8f, 7.8f), 6.5f, 1.0f);
            GameObject new_enemy = Instantiate(enemyprefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemycontainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator TripleShotRoutine()
    {
        while (stopspawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-7.8f, 7.8f), 6.5f, 1.0f);
            Instantiate(BonusPrefabs[Random.Range(0,1)], position, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    
    void Start()
    {

    }

    
    void Update()
    {
        
    }
}
