using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public GameObject whiteOutSquare
    ;

    public Color objectColor;

    void Start() {
        objectColor = whiteOutSquare
        .GetComponent<Image>().color;
    }

    public IEnumerator FadeOutBlack(bool fadeToBlack = true, int fadeSpeed = 5) 
    {
        float fadeAmount;

        if (fadeToBlack) 
        {
            while (whiteOutSquare
            .GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                whiteOutSquare
                .GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else 
        {
            while (whiteOutSquare
            .GetComponent<Image>().color.a > 0) 
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                whiteOutSquare
                .GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

    public void FadeIn() {
        StartCoroutine(FadeOutBlack(false));
    }

    public void FadeOut() {
        StartCoroutine(FadeOutBlack());
    }

}
