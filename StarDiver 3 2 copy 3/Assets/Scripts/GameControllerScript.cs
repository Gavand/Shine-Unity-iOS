using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript instance;
    public Text scoreText;
    public GameObject player;
    public GameObject settingsMenu;
    public GameObject gameOverMenu;
    public GameObject volumeMenu;
    public GameObject tutorialMenu;
    public GameObject tutorialImage;
    public GameObject tutNextButton;

    public Text healthBarText;

    private int score = 0;

    private bool gameOver = false;
    private bool gamePaused = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setHP(int healthpoints)
    {
        if (gameOver)
        {
            return;
        }

        healthBarText.text = "x" + healthpoints;
    }

    public void incrementScore(int points)
    {
        if (gameOver) {
            return;
        }

        score += points;
        scoreText.text = "Score: " + score.ToString();

        if (score >= DifficultySettings.winAmount)
        {
            string currentLevel = PlayerPrefs.GetString("CurrentLevel");
            PlayerPrefs.SetInt(currentLevel, 1);
        }
    }

    public void onclickSettingsButtons()
    {
        if (gamePaused)
        {
            unpauseGame();
            gamePaused = false;
        } else
        {
            pauseGame();
            gamePaused = true;
        }
    }

    public void onclickVolumeButton()
    {
        if (volumeMenu.activeSelf)
        {
            hideVolumeMenu();
            showSettingsMenu();
        } else
        {
            hideSettingsMenu();
            showVolumeMenu();
        }
    }

    public void onclickTutorialButton()
    {
        if (tutorialMenu.activeSelf)
        {
            hideTutorialMenu();
            showSettingsMenu();
        } else
        {
            hideSettingsMenu();
            showTutorialMenu();
        }
    }

    public void tutorialNextClick()
    {
        tutNextButton.SetActive(false);
        tutorialImage.SetActive(false);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void endGame()
    {
        gameOver = true;
        showGameOverMenu();
    }

    private void unpauseGame()
    {
        hideSettingsMenu();
        Time.timeScale = 1;
        player.GetComponent<Controls>().enabled = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void pauseGame()
    {
        showSettingsMenu();
        Time.timeScale = 0;
        player.GetComponent<Controls>().enabled = false;
    }

    private void showSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    private void hideSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    private void showGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    private void hideGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }

    private void showVolumeMenu()
    {
        volumeMenu.SetActive(true);
    }

    private void hideVolumeMenu()
    {
        volumeMenu.SetActive(false);
    }

    private void showTutorialMenu()
    {
        tutorialMenu.SetActive(true);
    }

    private void hideTutorialMenu()
    {
        tutorialMenu.SetActive(false);
    }
}
