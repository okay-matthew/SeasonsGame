using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap terrain, background, backgroundObjects;


    private void Update() {

        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = terrain.WorldToCell(mousePosition);
            SeasonManager season = SeasonManager.Instance;

            TileBase clickedTile = terrain.GetTile(gridPosition);

            Tile t = clickedTile as Tile;
            if (t != null) {
                Debug.Log("It's a tile: " + t);
                season.changeSeason();
                Debug.Log(season.getSeason());
                terrain.RefreshAllTiles();
                background.RefreshAllTiles();
                backgroundObjects.RefreshAllTiles();
            }
        }
    }
}
