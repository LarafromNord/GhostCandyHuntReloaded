using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Transform player;
    public float attractionSpeed = 1.5f;

    void Update()
    {
        transform.position = player.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
            Debug.Log("Candy found");
            CandyController candy = collision.GetComponent<CandyController>();
            candy.Attract(transform, attractionSpeed);
        }
    }

    public void magnetAbilityActivate()
    {
        
        gameObject.SetActive(GetComponent<PlayerController>().magnetAbilityValid);
    }
}
