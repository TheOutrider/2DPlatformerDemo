using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidBody;

    public float speed;
    float xInput;
    bool isGrounded;
    bool isSliding;
    bool doubleJump = true;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float jumpForce;
    Animator animator;
    int score;
    public TextMeshProUGUI scoreText;
    bool isDead = false;
    public bool isLevelCompleted = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if(gameObject.transform.position.x > 85)
        {
            Debug.Log("REACHED");
            isLevelCompleted = true;
        }
        Debug.Log("COMPLETED " + isLevelCompleted.ToString());
        if (!isDead && !isLevelCompleted)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            rigidBody.velocity = new Vector2(xInput * speed, rigidBody.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);
            if (Input.GetKeyDown(KeyCode.Space) && !isSliding)
            {
                if (isGrounded)
                {
                    Jump(1.0f);
                }
                else if (doubleJump)
                    Jump(1.5f);
                doubleJump = false;
            }

            if (isGrounded)
            {
                doubleJump = true;
            }
            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));

            if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded && !isSliding && !isDead)
            {
                isSliding = true;
                animator.SetBool("isSliding", isSliding);
                // gameObject.transform.position = Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1, gameObject.transform.position.z + 1).position;
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.30f);
                transform.localScale = new Vector3(transform.localScale.x + 0.20f, transform.localScale.y - 0.20f, 0);
                Invoke("StopSliding", 1);
            }

            CheckDirection();
        }
    }

    void StopSliding()
    {
        isSliding = false;
        animator.SetBool("isSliding", isSliding);
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.30f);
        transform.localScale = new Vector3(transform.localScale.x - 0.20f, transform.localScale.y + 0.20f, 0);
    }
    void Jump(float backForce)
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce / backForce);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "Coin")
        {
            collider.gameObject.SetActive(false);
            score++;
            scoreText.text = "C : " + score.ToString();
        }

        if (collider.gameObject.tag == "Spikes")
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log(other.gameObject.tag);
    // }

    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log(other.gameObject.tag);
    //     Debug.Log("CHECKPOIN1");
    // }

    void CheckDirection()
    {
        if (rigidBody.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (rigidBody.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
