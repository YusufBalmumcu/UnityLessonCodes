using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{


    private int health = 3;
    


    [SerializeField]
    public float speed = 2.0f;
    [SerializeField]
    public float horizontalInput;
    [SerializeField]
    public float verticalInput;
    [SerializeField]
    public float fireRate = 0.5f;
    [SerializeField]
    private float nextFire = 0.0f;

    public GameObject laserPrefab;

    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
    }


    void Update()
    {
        CalculateMovement();
        Fire();
    }

    void Fire(){
                if ((Input.GetKeyDown(KeyCode.Space)||(Input.GetKeyDown(KeyCode.Joystick1Button2)))&& Time.time > nextFire)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;       
        }
    }



    void CalculateMovement(){


        if (transform.position.x < 7.5 && transform.position.x > -7.5 && transform.position.y < 5 && transform.position.y > -3)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(direction * Time.deltaTime * speed);
        }
        else
        {
            if (transform.position.x > 7.5)
            {
                transform.position = new Vector3(7.49f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -7.5)
            {
                transform.position = new Vector3(-7.49f, transform.position.y, transform.position.z);
            }
            if (transform.position.y > 5)
            {
                transform.position = new Vector3(transform.position.x, 4.99f, transform.position.z);
            }
            if (transform.position.y < -3)
            {
                transform.position = new Vector3(transform.position.x, -2.99f, transform.position.z);
        }
    }
    }

    public void GetDamage()
    {
        health--;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
