using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
    Controls the the screen fade. Help from 
    https://turbofuture.com/graphic-design-video/How-to-Fade-to-Black-in-Unity#:~:text=In%20Unity%2C%20go%20to%20Assets,Voila.
*/
public class FadeController : MonoBehaviour
{
    [SerializeField]
    public GameObject fadeImage;

    public Color objectColor;

    void Start() {
        objectColor = fadeImage
        .GetComponent<Image>().color;
    }

    /* Enum to control fade */
    public IEnumerator FadeOutEnum(bool fadeTo = true, int fadeSpeed = 5) 
    {
        float fadeAmount;

        if (fadeTo) 
        {
            while (fadeImage
            .GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeImage
                .GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else 
        {
            while (fadeImage
            .GetComponent<Image>().color.a > 0) 
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeImage
                .GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

    /*
        Following methods allow for access to the fade.
    */
    public void FadeIn() {
        StartCoroutine(FadeOutEnum(false));
    }

    public void FadeOut() {
        StartCoroutine(FadeOutEnum());
    }

}
