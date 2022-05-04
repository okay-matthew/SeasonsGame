using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap terrain, background, backgroundObjects, water, extras;


    private void Update() {

        if (Input.GetKeyDown("r")) { //TODO: sorta a weird place for this, no?
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     Vector3Int gridPosition = terrain.WorldToCell(mousePosition);
        //     SeasonManager season = SeasonManager.Instance;

        //     TileBase clickedTile = terrain.GetTile(gridPosition);

        //     Tile t = clickedTile as Tile;
        // }
    }

    /*
        public method to refresh the tiles on each tilemap. As the sprite of a SeasonTile
        is updated after its corresponding tilemap refreshes, whenenver the season changes, call this  
        method.
    */
    public void RefreshTiles() {
        terrain.RefreshAllTiles();
        background.RefreshAllTiles();
        backgroundObjects.RefreshAllTiles();
        water.RefreshAllTiles();
        extras.RefreshAllTiles();
    }
}
