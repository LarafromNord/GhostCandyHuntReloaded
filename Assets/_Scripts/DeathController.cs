using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    private SpriteRenderer catRenderer;
    public Sprite[] dieingCatSprites;
    public PlayerController PController = null;

    // Start is called before the first frame update
    public void Dieing()
    {
        StartCoroutine(SpriteAnim(5));

    }

   
   
    IEnumerator SpriteAnim(float time)
    {
        yield return new WaitForSeconds(time);
        catRenderer.GetComponent<SpriteRenderer>().sprite = dieingCatSprites[0];
        yield return new WaitForSeconds(time);
        catRenderer.GetComponent<SpriteRenderer>().sprite = dieingCatSprites[1];
        yield return new WaitForSeconds(time*2);
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
