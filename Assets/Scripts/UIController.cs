using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField]
    public GameObject fadeImage;

    public Color objectColor;

    void Start() {
        objectColor = fadeImage
        .GetComponent<Image>().color;
    }

    public IEnumerator FadeOut(bool fadeTo = true, int fadeSpeed = 5) 
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

    public void FadeInBlack() {
        StartCoroutine(FadeOut(false));
    }

    public void FadeOutBlack() {
        StartCoroutine(FadeOut());
    }

}
