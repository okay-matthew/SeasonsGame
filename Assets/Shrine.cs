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

    private bool atShrine = false;

    

    void Start() {
        spaceKey.enabled = false;
        blackOutScript = GameObject.Find("FadeToBlack").GetComponent<UIController>();
    }

    void Update() {

        if (Input.GetButtonDown("Meditate") && atShrine) {

            blackOutScript.FadeOut(); //Script to fade out

            SeasonChange();

            blackOutScript.FadeIn(); // Script to fade in

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
}
