using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bonusscript : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update

    [SerializeField]
    int BonusId;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            if (BonusId == 0)
            {
                audioSource.Play();
                playerscript.ActivateTripleShot();
            }
            else if (BonusId == 1)
            {
                audioSource.Play();
                playerscript.ActivateSpeedBonus();
            }
                

            Destroy(this.gameObject);
        }
    }



}
