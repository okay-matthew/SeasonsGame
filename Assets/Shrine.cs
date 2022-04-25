using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Shrine : MonoBehaviour
{

    [SerializeField]
    private Tilemap terrain, background, backgroundObjects, water, extras;
    [SerializeField]
    private Image spaceKey;
    [SerializeField]
    
    UIController blackOutScript;

    PlayerMovement playerScript;

    private bool atShrine = false;

    

    void Start() {
        spaceKey.enabled = false;
        blackOutScript = GameObject.Find("FadeToBlack").GetComponent<UIController>();
        playerScript = GameObject.Find("Agate").GetComponent<PlayerMovement>();
    }

    void Update() {

        if (Input.GetButtonDown("Meditate") && atShrine) {
            StartCoroutine(SeasonTransition());
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            atShrine = true;
            spaceKey.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            atShrine = false;
            spaceKey.enabled = false;
        }
    }

    void SeasonChange() {
        SeasonManager season = SeasonManager.Instance;
        season.changeSeason();
        terrain.RefreshAllTiles();
        background.RefreshAllTiles();
        backgroundObjects.RefreshAllTiles();
        water.RefreshAllTiles();
        extras.RefreshAllTiles();
    }

    IEnumerator SeasonTransition() {
        playerScript.unpaused = false;
        blackOutScript.FadeOut();
        yield return new WaitForSeconds(2f);
        
        SeasonChange();
        playerScript.unpaused = true;
        blackOutScript.FadeIn();
    }


}
