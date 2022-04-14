using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbDetector : MonoBehaviour
{
    private bool orbsDeposited;
    private bool touchingOrbDepositor;
    // private int orbCounter;
    public Image enterKey; //I stole this image off the internet we should make our own
    public Text levelCompleteText;
    private int count;



    // Start is called before the first frame update
    void Start()
    {
        touchingOrbDepositor = false;
        levelCompleteText.text = "";
        count = 0;
        enterKey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOrbsDeposited();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            touchingOrbDepositor = true;
        } 
    }
    private void CheckOrbsDeposited() {
        if(touchingOrbDepositor && GameObject.FindGameObjectsWithTag("OrbFound").Length == 3){    
            enterKey.enabled = true;
            if(Input.GetButtonDown("Submit")){
                levelCompleteText.text = "Level Complete";
                Time.timeScale = 0;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            count++;
            touchingOrbDepositor = false;
            enterKey.enabled = false;
        }
    }
}
