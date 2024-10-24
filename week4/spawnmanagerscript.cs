using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanagerscript : MonoBehaviour
{
    [SerializeField]
    GameObject enemyprefab;

    [SerializeField]
    GameObject enemycontainer;

    bool stopspawning = false;

    public void OnPlayerDeath()
    {
        stopspawning = true;
    }

    IEnumerator SpawnRoutine()
    {
        while (stopspawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-7.8f, 7.8f), 6.5f, 1.0f);
            GameObject new_enemy = Instantiate(enemyprefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemycontainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
