using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugEnemyScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public float maxSpeed;

    public bool isVisible = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        Vector3 updatedSacle = transform.localScale;
        updatedSacle.x *= -1;
        transform.localScale = updatedSacle;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
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
