using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

 [CreateAssetMenu]
public class SeasonTiles : Tile {

    public Sprite fallSprite, winterSprite, springSprite, summerSprite;
    public Sprite newSprite;
    public SeasonManager season;
    void Start() {
        // newSprite = fallSprite;
    }

    void Update() {

    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref UnityEngine.Tilemaps.TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

            season = SeasonManager.Instance;

            switch (season.getSeason()) {
                case "fall": 
                    newSprite = fallSprite;
                    break;
                case "winter": 
                    newSprite = winterSprite;
                    break;
                case "spring": 
                    newSprite = springSprite;
                    break;
                case "summer": 
                    newSprite = summerSprite;
                    break;
                } 

        tileData.sprite = newSprite;
    }
}
    
