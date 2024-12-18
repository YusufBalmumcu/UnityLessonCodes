using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanagerscript : MonoBehaviour
{
    bool isGameOver = false;

    void Start()
    {
        
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver == true)
        {
            SceneManager.LoadScene(0); 
        }
    }



}
