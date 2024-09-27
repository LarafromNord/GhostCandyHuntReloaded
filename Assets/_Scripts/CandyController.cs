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

    void Start()
    {
        targetCandy.GetComponent<SpriteRenderer>().sprite = candySprites[Random.Range(0, candySprites.Length)];
        candyRarity = Random.Range(1, 4);
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
                candyPoints = 20; break;
        }    
     /*   if (candyRarity == 1f) { candyPoints = 1; }
        else if (candyRarity == 2f) { candyPoints = 3; }
        else if (candyRarity == 3f) { candyPoints = 5; }
        else if (candyRarity == 4f) { candyPoints = 20; }*/

    }
}