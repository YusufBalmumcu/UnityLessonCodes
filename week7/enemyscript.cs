using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    [SerializeField] 
    float speed = 3.0f;
    
    void Start()
    {
        
    }

        void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(Random.Range(-7.8f, 7.8f), 6.5f, 1.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Hit: " + other.name);
        if (other.tag == "Player")
        {
            playerscript playerscript =  other.GetComponent<playerscript>();
            playerscript.GetDamage();
            Destroy(this.gameObject);
        } else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
