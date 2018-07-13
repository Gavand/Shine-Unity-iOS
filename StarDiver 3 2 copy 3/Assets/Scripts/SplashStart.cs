using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashStart : MonoBehaviour {

    // Start the splash game
	public void onStartClick()
    {
        SceneManager.LoadScene("AR Big Dipper");
    }

}
