using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jump = 10f;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isKeyFound;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(PlayerName.finalPlayerName);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Debug.Log(isGrounded);
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box")
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    isGrounded = true;

                }
            }
        }

        if(collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            isKeyFound = true;
        }

        if(collision.gameObject.tag == "Door" && isKeyFound)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            onComplete();
        }
    }

    private void onComplete()
    {

        float score = TimerScript.timeRemaining;
        TimerScript.timerIsRunning = false;
        Debug.Log(score);
        PlayerName.gameComplete = true;
        SceneManager.LoadScene("Leaderboard");

    }
}
