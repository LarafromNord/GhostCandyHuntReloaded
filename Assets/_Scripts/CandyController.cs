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
        //   candyPoints = Random.Range(5, 20);
        candyRarity = Random.Range(1, 4);
        Debug.Log("CaPo " + candyPoints);
        //   targetCandy.GetComponent<SpriteRenderer>().color = [Random.Range(0, candySprites.Length)];
        if (candyRarity == 1f) { candyPoints = 1; }
        else if (candyRarity == 2f) { candyPoints = 3; }
        else if (candyRarity == 3f) { candyPoints = 5; }
        else if (candyRarity == 4f) { candyPoints = 20; }
        /*    switch (candyPoints) {
                   case 1:
                    candyRarity = 1;
                       candyPoints = 1;
                       break;
                   case 2:
                    candyRarity = 2;
                    candyPoints = 3;
                       break;
                   case 3:
                    candyRarity = 3;
                    candyPoints = 5;
                       break;
                   case 4:
                       candyPoints = 10;
                       break;
                   case 5:
                       candyPoints = 20;
                       break;*/
    }
}