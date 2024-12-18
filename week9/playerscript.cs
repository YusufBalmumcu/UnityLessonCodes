using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{


    private int health = 3;

    [SerializeField]
    int score = 0;
    


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

    [SerializeField]
    int speedBonusMultiplier = 2;


    bool isTripleShotActive = false;
    bool isSpeedBonusActive = false;

    spawnmanagerscript spawnmanagerscript;
    UImanagerscript UImanagerscript;

    public GameObject laserPrefab;

    public GameObject tripleShotPrefab;

    [SerializeField]
    GameObject rightEngine;
    [SerializeField]
    GameObject leftEngine;

    void Start()
    {
        transform.position = new Vector3(1, 1, 1);

        UImanagerscript = GameObject.Find("Canvas").GetComponent<UImanagerscript>();

        spawnmanagerscript = GameObject.Find("Spawn_Manager").GetComponent<spawnmanagerscript>();
        if (spawnmanagerscript == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }
                if (UImanagerscript == null)
        {
            Debug.LogError("UI Manager is NULL");
        }
    }


    void Update()
    {
        CalculateMovement();
        Fire();
    }

    void Fire(){
                if ((Input.GetKeyDown(KeyCode.Space)||(Input.GetKeyDown(KeyCode.Joystick1Button2)))&& Time.time > nextFire)
        {
            if (isTripleShotActive == true)
            {
                Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
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

        if (health == 2)
        {
            rightEngine.SetActive(true);
        }
        else if (health == 1)
        {
            leftEngine.SetActive(true);
        }

        UImanagerscript.UpdateLives(health);
        if(health <= 0)
        {
            spawnmanagerscript.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        speed *= speedBonusMultiplier;
        // 5 seconds later
        StartCoroutine(TripleShotBonusDisableRoutine());
    }

    public void ActivateSpeedBonus()
    {
        isSpeedBonusActive = true;
        // 5 seconds later
        StartCoroutine(SpeedBonusDisableRoutine());
    }
    IEnumerator SpeedBonusDisableRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBonusActive = false;
    }


    IEnumerator TripleShotBonusDisableRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }


    public void UpdateScore()
    {
        score += 10;
        UImanagerscript.UpdateScoreTMP(score);
    }

}
