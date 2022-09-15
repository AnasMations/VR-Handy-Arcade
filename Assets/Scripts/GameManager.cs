using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    public TextMeshPro scoreText;
    public string gameId;
    public TextMeshPro highScoreText;
    public float TimerValue;
    private float tempTimerValue;
    public TextMeshPro TimerText;
    private int isGameOver = 0;

    // Start is called before the first frame update
    void Start()
    {
        tempTimerValue = TimerValue;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt(gameId).ToString();

        if(TimerValue > 0)
        {
            TimerValue -= Time.deltaTime;
        }else
        {
            TimerValue = 0;
            if(isGameOver==0)
            {
                isGameOver=1;
            }
        }

        if(isGameOver==1)
        {
            FindObjectOfType<AudioManager>().Play("gameOver");
            isGameOver = -1;
        }

        if(score > PlayerPrefs.GetInt(gameId))
        {
            PlayerPrefs.SetInt(gameId, score);
        }

        TimerText.text = string.Format("{0:00}", TimerValue);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
