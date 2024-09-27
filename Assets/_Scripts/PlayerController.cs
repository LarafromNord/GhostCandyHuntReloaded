using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite[] catSprites;
    public float speed = 5.5f;
    private float jumpForce = 450f;
    public int scorePoints;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioSource deathSource;
    public AudioClip deathSound;
    private SpriteRenderer catRenderer;
    private int maxJump = 1;
    private int currentjumps;
    private bool isJumping;
    private bool Dashing = false;
    public float dashTime = 1;
    public float dashCurrentTime = 0;
    public bool dashAbilityValid = false;
    public bool jumpAbilityValid = false;
    public bool magnetAbilityValid = false;
    public bool isDieing = false;
    private float abilityMultuplier;

    public CandyController CControllerC = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        catRenderer = GetComponent<SpriteRenderer>();
        SpriteStateSwitch();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentjumps < maxJump)
            {
                jump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentjumps < maxJump)
            {
                jump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentjumps < maxJump)
            {
                jump();
            }
        }

        if (!isJumping)
        {
            float HorizontalDirection = Input.GetAxis("horizontal");
            transform.Translate(HorizontalDirection * speed * abilityMultuplier * Time.deltaTime * Vector2.right);
            if (HorizontalDirection < 0)
            {
                catRenderer.flipX = true;
            }
            else
            {
                catRenderer.flipX = false;
            }
        }
        


 /*       if (Input.GetKey(KeyCode.A))
        {
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            
        }

/*        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
            catRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            catRenderer.flipX = false;
        }*/

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dashing = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Dashing = false;
            Dash();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject hitObject = other.gameObject;
        Debug.Log("Hit: " + hitObject.tag);
        int inPoints;

        if (other.gameObject.CompareTag("Candy"))
        {
            scorePoints = scorePoints + CControllerC.candyPoints;
            Destroy(other.gameObject);
            Debug.Log(scorePoints);

        }
        
        else if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("Sound");
            deathSource.PlayOneShot(deathSound);
            isDieing = true;
            SpriteStateSwitch();
            Death();
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentjumps = 0;
            Debug.Log(currentjumps);
            //  isJumping = false;
        }
    }

    public void Dash()
    {
        if (dashCurrentTime < dashTime)
        {
            dashCurrentTime++;
            speed = 40f;
        }
        else
        {
            dashCurrentTime = 0;
            speed = 4.5f;
        }
    }

    public void jump()
    {
        if (currentjumps < maxJump)
        {
            rb.AddForce(transform.up * jumpForce);
            currentjumps += 1;

            audioSource.PlayOneShot(jumpSound, 0.7F);
            //  isJumping = true;
        }
    }

    public void Death()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void SpriteStateSwitch()
    {
        if (!isDieing)
        {
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[0];
        }
        else if (dashAbilityValid)
        {
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[3];
        }
        else if (jumpAbilityValid)
        {
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[4];
        }
        else if (magnetAbilityValid)
        {
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[5];
        }
        else if (isDieing)
        {
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[1];
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[2];
        }
    }
}