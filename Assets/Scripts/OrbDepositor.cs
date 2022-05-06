using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* Manages everything to do with the orb depositor
*/
public class OrbDepositor : MonoBehaviour
{
    private bool orbsDeposited; // true after player presses enter and orbs have been deposited
    private bool touchingOrbDepositor; // true when player is colliding with orb depositor
    public Image enterKey; // image that indicates to press enter when touching orb depositor
    public Text levelCompleteText; // text that indicates completed level

    private UIController whiteOutScript;  



    // Start is called before the first frame update
    void Start()
    {
        whiteOutScript = GameObject.Find("FadeToWhite").GetComponent<UIController>();
        touchingOrbDepositor = false;
        levelCompleteText.text = "";
        enterKey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOrbsDeposited();
        
        if(Input.GetKeyDown(KeyCode.R)){ // Allows player to reset level after winning
            Time.timeScale = 1;
        }
    }
    
    /**
    * Indicates when the orb detector and player are touching
    */
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            touchingOrbDepositor = true;
        } 
    }

    /**
    * Checks whether the player has found all the orbs and is touching the depositor, if so allows the user to deposit the orbs and ends level
    */
    private void CheckOrbsDeposited() {
        if(touchingOrbDepositor && GameObject.FindGameObjectsWithTag("OrbFound").Length == 3){    
            enterKey.enabled = true;
            if(Input.GetButtonDown("Submit")){
                 // loads next scene
                StartCoroutine(LevelTransition());
                

            }
        }
    }
    
    /**
    * Indicates when player and orb depositor are not touching
    */
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            touchingOrbDepositor = false;
            enterKey.enabled = false;
        }
    }

    /*
    Times out events of level transition
    */
    IEnumerator LevelTransition() {
        
        levelCompleteText.text = "Level Complete"; //shows text
        yield return new WaitForSeconds(1f);

        whiteOutScript.FadeOut();   //Fades out after a second
        yield return new WaitForSeconds(1f); //waits

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene
    }
}
