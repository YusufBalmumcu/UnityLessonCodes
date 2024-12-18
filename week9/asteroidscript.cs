using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class asteroidscript : MonoBehaviour
{

    float rotateSpeed = 20.0f;

    [SerializeField]
    GameObject explosionPrefab;

    spawnmanagerscript spawnmanager;

    // Start is called before the first frame update
    void Start()
    {
        spawnmanager = GameObject.Find("SpawnManager").GetComponent<spawnmanagerscript>();
        if (spawnmanager == null)
        {
            Debug.LogError("Asteroidscript: The Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            spawnmanager.StartSpawning();
            Destroy(this.gameObject);
        }
    }



}
