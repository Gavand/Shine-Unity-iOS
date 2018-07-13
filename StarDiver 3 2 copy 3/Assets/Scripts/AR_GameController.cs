using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AR_GameController : MonoBehaviour {

    public static AR_GameController instance;

    public Text statusText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        string currentLevel = PlayerPrefs.GetString("CurrentLevel", "N/A");
        bool isCompleted = PlayerPrefs.GetInt(currentLevel, 0) == 1 ? true : false;
        if (isCompleted)
        {
            statusText.text = "Status: Completed";
            statusText.color = Color.green;
        } else
        {
            statusText.text = "Status: Not Completed";
            statusText.color = Color.red;
        }
    }


    public void backButtonOnClick()
    {
        SceneManager.LoadScene("AR Big Dipper");
    }

    public void playButtonOnClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void setEasyDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", DifficultySettings.DIFFICULTY_LEVEL_EASY);
    }

    public void setNormalDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", DifficultySettings.DIFFICULTY_LEVEL_NORMAL);
    }

    public void setHardDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", DifficultySettings.DIFFICULTY_LEVEL_HARD);
    }
}
