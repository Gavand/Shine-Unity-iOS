using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Tutorial : MonoBehaviour {

	// Use this for initialization
	public static GameControllerScript instance;
	public GameObject tutorialMenu;
	public GameObject tutorialImage;
	public GameObject tutNextButton;

	public void onclickTutorialButton()
	{
			if (tutorialMenu.activeSelf)
			{
					hideTutorialMenu();
			} else
			{
					showTutorialMenu();
			}
	}

	public void tutorialNextClick()
	{
			tutNextButton.SetActive(false);
			tutorialImage.SetActive(false);
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
