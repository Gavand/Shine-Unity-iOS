using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemyScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public GameObject player;

    public float maxSpeed_x;
    public float maxSpeed_y;

    public bool isVisible = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameControllerScript.instance.player;
    }

    // Use this for initialization
    void Start()
    {
        Vector3 updatedSacle = transform.localScale;
        updatedSacle.x *= -1;
        transform.localScale = updatedSacle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isVisible)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += maxSpeed_x;

            if (transform.position.y < player.transform.position.y)
            {
                newPosition.y += maxSpeed_y;
            }
            else if (transform.position.y > player.transform.position.y)
            {
                newPosition.y += -maxSpeed_y;
            }
            transform.position = newPosition;
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }
}
