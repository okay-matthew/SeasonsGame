using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

/* Manages the refreshing of tiles and has potential to handle other
 actions to perform on the tilemaps
*/

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap terrain, background, bounceshrooms, trees, leaves, water, extras;


    private void Update() {

        if (Input.GetKeyDown("r")) { //TODO: sorta a weird place for this, no?
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /*
        public method to refresh the tiles on each tilemap. As the sprite of a SeasonTile
        is updated after its corresponding tilemap refreshes, whenenver the season changes, call this  
        method.
    */
    public void RefreshTiles() {
        terrain.RefreshAllTiles();
        background.RefreshAllTiles();
        bounceshrooms.RefreshAllTiles();
        trees.RefreshAllTiles();
        leaves.RefreshAllTiles();
        water.RefreshAllTiles();
        extras.RefreshAllTiles();
    }
}
