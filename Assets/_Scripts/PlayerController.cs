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
    private float jumpForce = 285f;
    public int scorePoints;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioSource deathSource;
    public AudioClip deathSound;
    private SpriteRenderer catRenderer;
    public GameObject magnetObject;
    private int maxJump = 1;
    private int currentjumps;
    private bool isJumping;
    private bool Dashing = false;
    public float dashTime = 1;
    public int abilityType;
    public float dashCurrentTime = 0;
    public bool dashAbilityValid = false;
    public bool jumpAbilityValid = false;
    public bool magnetAbilityValid = false;
    public bool isDieing = false;
    private float abilityMultuplier;
    private float jumpAbilityMultiplier;
    public GameObject deathCat;

 //   public CandyController CControllerC = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        catRenderer = GetComponent<SpriteRenderer>();
        SpriteStateSwitch();
        AbilityData();
        magnetObject.SetActive(false);
        dashAbilityValid = true;
    }

    void Update()
    {
        if (Dashing)
        {
            return;
        }

 /*       if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentjumps < maxJump)
            {
                jump();
            }
        }*/
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
            float HorizontalDirection = Input.GetAxis("Horizontal");
            transform.Translate(HorizontalDirection * speed * Time.deltaTime * Vector2.right);
            if (HorizontalDirection < 0)
            {
                catRenderer.flipX = true;
            }
            else if (HorizontalDirection > 0)
            {
                catRenderer.flipX = false;
            }
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dashing = true;
            Dash();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Dashing = false;
        //    Dash();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject hitObject = other.gameObject;
        Debug.Log("Hit: " + hitObject.tag);
        
        if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("Sound");
         //   deathSource.PlayOneShot(deathSound);
            isDieing = true;
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
        else if (collision.gameObject.CompareTag("Candy"))
        {
            scorePoints = scorePoints + collision.gameObject.GetComponent<CandyController>().candyPoints;
            abilityType = scorePoints + collision.gameObject.GetComponent<CandyController>().specialAbilityType;
            Destroy(collision.gameObject);
            Debug.Log(scorePoints);
            ActivateAbilities();
            AbilityData();
        }
    }

    public void Dash()
    {
        StartCoroutine(dashingCoroutine());
    }

    public void jump()
    {
        if (currentjumps < maxJump)
        {
            rb.AddForce(transform.up * (jumpForce * jumpAbilityMultiplier));
            currentjumps += 1;

            audioSource.PlayOneShot(jumpSound, 0.7F);
        }
    }

    public void Death()
    {

        var c = Instantiate(deathCat);
        c.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
     //   StartCoroutine(DeathCoroutine());
     //   SceneManager.LoadScene("GameOverScene");
    }

    public void SpriteStateSwitch()
    {
        if (!isDieing)
        {
            catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[0];

            if (dashAbilityValid)
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
            else
            {
                catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[0];
            }
        }
    }

    void ActivateAbilities()
    {
        SpriteStateSwitch();
        StartCoroutine(dashAbilityCoroutine());
        StartCoroutine(magnetAbilityCoroutine());
        StartCoroutine(magnetAbilityCoroutine());
    }

    IEnumerator magnetAbilityCoroutine()
    {
        magnetObject.SetActive(true);

        yield return new WaitForSeconds(0.05f);
        AbilityData();

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        magnetObject.SetActive(false);
    }

    IEnumerator dashAbilityCoroutine()
    {

        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        dashAbilityValid = true;
        Debug.Log("Dashing allowed");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        dashAbilityValid = false;
        Debug.Log("Dashing not allowed");
    }

    IEnumerator JumpAbilityCoroutine()
    {

        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        jumpAbilityValid = true;
        Debug.Log("Dashing allowed");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        jumpAbilityValid = false;
        Debug.Log("Dashing not allowed");
    }

    IEnumerator dashingCoroutine()
    {
        float dashTime = 0.5f;
        float Horizontal = 1f;
        if (catRenderer.flipX)
        {
            Horizontal = -1f;
        }
        else
        {
            Horizontal = 1f;
        }
       

        while (dashTime > 0.0f)
        {
            dashTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            transform.Translate(Horizontal * speed * abilityMultuplier * Time.deltaTime * Vector2.right);
        }
        dashAbilityValid = false;
    }

    void AbilityData()
    {
        switch (abilityType)
        {
            case 1:
                dashAbilityValid = true;
                abilityMultuplier = 2f;
                break;
            case 2:
                jumpAbilityValid = true;
                abilityMultuplier = 1f;
                jumpAbilityMultiplier = 1.6f;
                break;
            case 3:
                magnetAbilityValid = true;
                abilityMultuplier = 1f;
                break;
            default:
                dashAbilityValid = false;
                jumpAbilityValid = false;
                magnetAbilityValid = false;
                abilityMultuplier = 1f;
                jumpAbilityMultiplier = 1.0f;
                break;
        }
    }
}