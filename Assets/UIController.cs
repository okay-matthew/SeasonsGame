using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public GameObject blackOutSquare;

    public Color objectColor;

    void Start() {
        objectColor = blackOutSquare.GetComponent<Image>().color;
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.A)) 
        // {
        //     StartCoroutine(FadeOutBlack());
        // }
        // if (Input.GetKeyDown(KeyCode.S)) {
        //     StartCoroutine(FadeOutBlack(false));
        // }
    }

    public IEnumerator FadeOutBlack(bool fadeToBlack = true, int fadeSpeed = 5) 
    {
        float fadeAmount;

        if (fadeToBlack) 
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else 
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0) 
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
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
