using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class CandyController : MonoBehaviour
{
    public Sprite[] candySprites;
    public int candyPoints;
    public Transform targetCandy;
    public int candyRarity;
    public int specialAbilityType;


    void Start()
    {
        targetCandy.GetComponent<SpriteRenderer>().sprite = candySprites[Random.Range(0, candySprites.Length)];
        candyRarity = Random.Range(0, 4);
        Debug.Log("CaPo " + candyPoints);
        //   targetCandy.GetComponent<SpriteRenderer>().color = [Random.Range(0, candySprites.Length)];
        switch(candyRarity)
        {
            case 0:
                candyPoints = 1; break;
                case 1:
                candyPoints = 3; break;
                case 2:
                candyPoints = 5; break;
                case 3:
                candyPoints = 20;
                specialAbilityType = Random.Range(1, 5);
                break;
        }
    }

    public void Attract(Transform target, float speed)
    {
        transform.position = Vector2.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }
}