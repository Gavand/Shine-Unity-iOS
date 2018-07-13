using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Controls : MonoBehaviour {
    public int maxHP = 3;
    private int currentHP;

    public float maxSpeed = 5f;
    public float jumpForce = 700f;

    private bool facingRight = true;
    private Rigidbody2D rigidBody;
    private bool isOnGround = true;

    public Transform groundCheck;
    public LayerMask groundLayers;
    float groundRadius = 0.2f;

    public float knockbackForceX = 500f;
    public float knockbackForceY = 500f;
    private bool isKnockedBack = false;

    private Animator playerAnim;

    private AudioSource playerAudio;
    public AudioClip runningAudioClip;
    public AudioClip damageAudioClip;
    public AudioClip jumpAudioClip;

    public bool doubleJump;

    private bool isInvincible = false;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        currentHP = maxHP;
	}

    private void Update() {
        if (isOnGround && CnInputManager.GetButtonDown("Jump")) {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            playerAnim.SetBool("Ground", false);
            playerAudio.PlayOneShot(jumpAudioClip);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float movement = CnInputManager.GetAxis("Horizontal");

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayers);
        playerAnim.SetBool("Ground", isOnGround);

        playerAnim.SetFloat("Speed", Mathf.Abs(movement));

        // if the player is being knocked back, remove controls
        if (isKnockedBack)
        {
            return;
        }

        rigidBody.velocity = new Vector2(movement * maxSpeed, rigidBody.velocity.y);
        if (Mathf.Abs(movement) > 0 && !playerAudio.isPlaying && isOnGround)
        {
            playerAudio.PlayOneShot(runningAudioClip);
        }
        if ((movement > 0 && !facingRight) || (movement < 0 && facingRight)) {
            Flip();
        }


        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Min(pos.x, 0.97f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 updatedSacle = transform.localScale;
        updatedSacle.x *= -1;
        transform.localScale = updatedSacle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && !isInvincible)
        {
            isInvincible = true;
            Invoke("endInvincibility", 2);
            InvokeRepeating("blinkSprite", 0, 0.22f);
            currentHP--;
            GameControllerScript.instance.setHP(currentHP);
            playerAudio.PlayOneShot(damageAudioClip);

            isKnockedBack = true;
            Invoke("endKnockback", 0.4f);
            rigidBody.velocity = new Vector2(0, 0);
            if (facingRight)
            {
                rigidBody.AddForce(new Vector2(-knockbackForceX, knockbackForceY));
            } else
            {
                rigidBody.AddForce(new Vector2(knockbackForceX, knockbackForceY));
            }

            if (currentHP <= 0)
            {
                killPlayer();
                GameControllerScript.instance.endGame();
            }
        }
    }

    private void killPlayer()
    {
        playerAnim.SetBool("Dead", true);
        gameObject.GetComponent<Controls>().enabled = false;
    }

    private void endKnockback()
    {
        isKnockedBack = false;
    }

    private void endInvincibility()
    {
        isInvincible = false;
        CancelInvoke("blinkSprite");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0 || pos.y < 0)
        {
            GameControllerScript.instance.setHP(0);
            killPlayer();
            GameControllerScript.instance.endGame();
        }
    }

    private void blinkSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
        OnBecameInvisible();
    }
}
