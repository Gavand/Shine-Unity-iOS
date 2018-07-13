using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

    public float scrollSpeed = 4f;

	// Use this for initialization
	void Start () {
        float speedupTimer = DifficultySettings.speedupTimer;
        InvokeRepeating("increaseScrollSpeed", speedupTimer, speedupTimer);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = transform.position;
        pos.x += scrollSpeed;
        transform.position = pos;
	}

    private void increaseScrollSpeed()
    {
        scrollSpeed += 0.01f;
    }
}
