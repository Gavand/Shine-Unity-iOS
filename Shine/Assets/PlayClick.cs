using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayClick : MonoBehaviour {

	[SerializeField]
	private string play = ""; // insert game scene to play
	void OnMouseDown ()
	{
		SceneManager.LoadScene(play);
	}

}