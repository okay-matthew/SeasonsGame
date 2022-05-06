using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

/*
 Public script for the shrine. The shrine allows the player to change the season in game while pressing 'space' while touching it. 
*/
public class Shrine : MonoBehaviour
{

    [SerializeField]
    private Image spaceKey; //Image which appears whenever the player comes into contact with the shrine.
    [SerializeField]
    private MapManager mapManager;
    
    private FadeController whiteOutScript; //script for fade transition

    private PlayerMovement playerScript;
    private bool atShrine = false;

    

    void Start() {
        spaceKey.enabled = false;
        whiteOutScript = GameObject.Find("FadeToWhite").GetComponent<FadeController>();
        playerScript = GameObject.Find("Agate").GetComponent<PlayerMovement>();
    }

    void Update() {

        if (Input.GetButtonDown("Space") && atShrine) { //TODO: maybe change all buttons to raw input, rather than our jargon
            StartCoroutine(SeasonTransition());
        }

    }

    /*
    When the player enters the shrine's area, shows the spacekey image.
    Sets bool to flag that the player is in the shrine's area.
    */
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            atShrine = true;
            spaceKey.enabled = true;
        }
    }

    /*
    When the player exits the shrine's area, spacekey image is removed.
    Sets bool to flag that the player is outside the shrine's area.
    */
    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            atShrine = false;
            spaceKey.enabled = false;
        }
    }

    void SeasonChange() {
        SeasonManager season = SeasonManager.Instance;
        season.changeSeason();
        mapManager.RefreshTiles(); // refreshes tiles to update seasontile sprites
    }

    /*
    Run with coroutine to time tilemap refresh. Else an akward season change occurs before
    the white fade. This makes it so that it happens behind the white fade.
    */
    IEnumerator SeasonTransition() {
        playerScript.unpaused = false;
        playerScript.rb.velocity = new Vector2(0, 0); // removes glitch where player 'slides' on ground when space is pressed near shrine
        whiteOutScript.FadeOut();                // while moving. Sometimes this would cause players to slide off edge.
        yield return new WaitForSeconds(1f);
        
        SeasonChange();
        playerScript.unpaused = true;
        whiteOutScript.FadeIn();
    }

}
