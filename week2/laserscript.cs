using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 10);

        if (transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }
}
