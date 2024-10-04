using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    private SpriteRenderer catRenderer;
    public Sprite[] dieingCatSprites;


    private void Start()
    {
        StartCoroutine(SpriteAnim(0.25f));
    }

   
   
    IEnumerator SpriteAnim(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().sprite = dieingCatSprites[0];
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().sprite = dieingCatSprites[1];
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("GameOverScene");
    }
    //public void SpriteStateSwitch()
    //{
    //    if (!isDieing)
    //    {
    //        catRenderer.GetComponent<SpriteRenderer>().sprite = catSprites[0];
    //    }
    //    else if (isDieing)
    //    {
    //        catRenderer.GetComponent<SpriteRenderer>().sprite = dieingCatSprites[0];
    //        catRenderer.GetComponent<SpriteRenderer>().sprite = dieingCatSprites[1];
    //    }
    //}
}
