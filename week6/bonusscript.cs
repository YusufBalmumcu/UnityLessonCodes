using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusscript : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            playerscript playerscript =  other.GetComponent<playerscript>();
            if (playerscript != null)
            {
                playerscript.ActivateTripleShot();
            }


            Destroy(this.gameObject);
        }
    }
}
