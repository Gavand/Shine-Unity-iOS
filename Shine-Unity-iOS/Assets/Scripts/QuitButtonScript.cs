using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour {

    public void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    public void OnExitLevelButtonClick()
    {
        GameControllerScript.instance.onclickSettingsButtons();
        SceneManager.LoadScene("AR Big Dipper");
    }
}
