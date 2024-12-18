using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanagerscript : MonoBehaviour
{

    gamemanagerscript gamemanagerscript;

    [SerializeField]
    TextMeshProUGUI scoreTMP;

    [SerializeField]
    Image livesImage;

    [SerializeField]
    Sprite[] livesSprites;

    [SerializeField]
    TextMeshProUGUI gameOverTMP;

    [SerializeField]
    TextMeshProUGUI restartTMP;



    void Start()
    {
        gamemanagerscript = GameObject.Find("Game_Manager").GetComponent<gamemanagerscript>();
        if (gamemanagerscript == null)
        {
            Debug.LogError("Game Manager is NULL");
        }

        scoreTMP.text = "Score: " + 0;
        livesImage.sprite = livesSprites[3];
        restartTMP.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void UpdateScoreTMP(int score)
    {
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLives(int Lives)
    {
        livesImage.sprite = livesSprites[Lives];

        if (Lives == 0)
        {
            GameOverSequence();
        }
    }

    public void GameOverSequence()
    {
        if (gamemanagerscript != null)
        {
            gamemanagerscript.GameOver();
        }
        restartTMP.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOverTMP.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverTMP.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
