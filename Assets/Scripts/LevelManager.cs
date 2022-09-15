using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject []Levels;

    void Awake()
    {
        Levels[PlayerPrefs.GetInt("currentLevel")].SetActive(true);
    }

    public void ChangeLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("currentLevel", levelIndex);
        SceneManager.LoadScene("Arcade");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
