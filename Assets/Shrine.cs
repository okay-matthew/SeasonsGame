using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Shrine : MonoBehaviour
{

    [SerializeField]
    private Tilemap terrain, background, backgroundObjects;
    [SerializeField]
    // private Image spaceKey;

    private bool atShrine = false;

    void Start() {
        // spaceKey.enabled = false;
    }

    void Update() {
        if (Input.GetButtonDown("Meditate") && atShrine) {
            SeasonManager season = SeasonManager.Instance;
            season.changeSeason();
            terrain.RefreshAllTiles();
            background.RefreshAllTiles();
            backgroundObjects.RefreshAllTiles();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            atShrine = true;
            // spaceKey.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            atShrine = false;
            // spaceKey.enabled = false;
            // shrineText.text ="";
        }
    }
}
