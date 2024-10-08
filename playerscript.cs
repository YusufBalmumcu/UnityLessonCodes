using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{

    public float speed = 2.0f;
    public float horizontalInput;
    public float verticalInput;

    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
    }
}
