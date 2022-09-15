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

    public void ChangeScene(int levelIndex)
    {
        PlayerPrefs.SetInt("currentLevel", levelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
