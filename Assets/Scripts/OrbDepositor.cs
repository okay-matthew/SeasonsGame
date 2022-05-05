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
    private bool orbsDeposited;
    private bool touchingOrbDepositor;
    public Image enterKey;
    public Text levelCompleteText;



    // Start is called before the first frame update
    void Start()
    {
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
    * Checks whether the player has found all the orbs and is touching the depositor, if so allows the user to deposit the orbs
    */
    private void CheckOrbsDeposited() {
        if(touchingOrbDepositor && GameObject.FindGameObjectsWithTag("OrbFound").Length == 3){    
            enterKey.enabled = true;
            if(Input.GetButtonDown("Submit")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelCompleteText.text = "Level Complete";
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
}
