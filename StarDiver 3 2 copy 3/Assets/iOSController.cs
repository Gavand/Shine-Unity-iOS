using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iOSController : MonoBehaviour {

	public GameObject player;

	     // Use this for initialization
	     void Start () {

	     }

	     // Update is called once per frame
	     void Update () {

	         if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
	         {
	             Vector2 touchPosition = Input.GetTouch(0).position;
	             double halfScreen = Screen.width / 2.0;

	             //Check if it is left or right?
	             if(touchPosition.x < halfScreen){
	                 player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
	             } else if (touchPosition.x > halfScreen) {
	                 player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
	             }

	         }

	     }
	 }
