using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarInfo : MonoBehaviour {

    public const string PLATFORMER_SCENE_EASY = "First Star";
    public const string PLATFORMER_SCENE_NORMAL = "Second Star";
    public const string PLATFORMER_SCENE_HARD = "Third Star";

    public string levelName = "";
    public int difficultyLevel = -1;

    private string sceneToLoad;

	// Use this for initialization
	void Start () {
        switch (difficultyLevel)
        {
            case DifficultySettings.DIFFICULTY_LEVEL_EASY:
                sceneToLoad = PLATFORMER_SCENE_EASY;
                break;
            case DifficultySettings.DIFFICULTY_LEVEL_NORMAL:
                sceneToLoad = PLATFORMER_SCENE_NORMAL;
                break;
            case DifficultySettings.DIFFICULTY_LEVEL_HARD:
                sceneToLoad = PLATFORMER_SCENE_HARD;
                break;
            default:
                Debug.LogError("Invalid difficulty setting set");
                break;
        }
    }

    void OnMouseDown()
    {
        PlayerPrefs.SetString("CurrentLevel", levelName);
        SceneManager.LoadScene(sceneToLoad);
    }
}
