using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashSequencer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> SplashFrames;

    [SerializeField]
    private Image mask;

    [SerializeField]
    private Image splash;

    [SerializeField]
    private float seconds = 5f;

    [SerializeField]
    private Sprite blackBG;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySplashSequence());
    }

    IEnumerator PlaySplashSequence()
    {
        foreach (var frame in SplashFrames)
        {
            splash.sprite = frame;
            // Fade out
            Color tempColorX = mask.color;
            for (float alpha = 1; alpha >= 0; alpha -= 0.05f)
            {
                tempColorX.a = alpha;
                mask.color = tempColorX;
                yield return new WaitForSeconds(0.05f);
            }
            tempColorX.a = 0;
            mask.color = tempColorX;
            yield return new WaitForSeconds(seconds);

            // Fade in
            for (float alpha = 0; alpha <= 1; alpha += 0.05f)
            {
                tempColorX.a = alpha;
                mask.color = tempColorX;
                yield return new WaitForSeconds(0.05f);
            }

            tempColorX.a = 1;
            mask.color = tempColorX;



        }
        // Fade out

        Color tempColor = mask.color;
        splash.sprite = blackBG;
        for (float alpha = 1; alpha >= 0; alpha -= 0.05f)
        {
            tempColor.a = alpha;
            mask.color = tempColor;
            yield return new WaitForSeconds(0.05f);
        }
        this.gameObject.SetActive(false);
    }
}
