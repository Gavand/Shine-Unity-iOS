using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCollissionScript : MonoBehaviour {

    // how many points the token is worth
    public int points;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameControllerScript.instance.incrementScore(points);
            Destroy(gameObject);
        }
    }
}
