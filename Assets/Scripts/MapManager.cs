using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap terrian;
    [SerializeField]
    private Tilemap background;
    [SerializeField]
    private Tilemap backgroundObjects;
    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles; 


    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = terrian.WorldToCell(mousePosition);
            SeasonManager season = SeasonManager.Instance;

            TileBase clickedTile = terrian.GetTile(gridPosition);

            Tile t = clickedTile as Tile;
            if (t != null) {
                Debug.Log("It's a tile: " + t);
                season.changeSeason();
                Debug.Log(season.getSeason());
                terrian.RefreshAllTiles();
                background.RefreshAllTiles();
                backgroundObjects.RefreshAllTiles();
            }
        }
    }
}
