using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomcam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Camera> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (StarControl.zoomActive == "y") {
			GetComponent<Camera> ().enabled = true;
		}
	}
}
