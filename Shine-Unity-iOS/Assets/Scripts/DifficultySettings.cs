using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySettings : MonoBehaviour {

    public const int DIFFICULTY_LEVEL_EASY = 0;
    public const int DIFFICULTY_LEVEL_NORMAL = 1;
    public const int DIFFICULTY_LEVEL_HARD = 2;

    public static DifficultySettings instance;

    public static float cameraScrollSpeed;
    public static float playerSpeed;
    public static float speedupTimer;
    public static int winAmount;
    public static GameObject tile;

    public GameObject[] tilePrefabs;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        int difficultyLevel = PlayerPrefs.GetInt("Difficulty");
        switch (difficultyLevel)
        {
            case DIFFICULTY_LEVEL_EASY:
                speedupTimer = 30.0f;
                winAmount = 10;
                break;
            case DIFFICULTY_LEVEL_NORMAL:
                speedupTimer = 15.0f;
                winAmount = 20;
                break;
            case DIFFICULTY_LEVEL_HARD:
                speedupTimer = 5.0f;
                winAmount = 40;
                break;
            default:
                Debug.LogError("Invalid difficulty level: " + difficultyLevel);
                break;
        }

        tile = tilePrefabs[difficultyLevel];
    }
}
