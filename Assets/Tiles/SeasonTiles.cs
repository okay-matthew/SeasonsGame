using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

 [CreateAssetMenu]
public class SeasonTiles : Tile {

    public Sprite fallSprite, winterSprite, springSprite, summerSprite;
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
        Sprite newSprite = null;

        switch (season.getSeason()) {
            case Season.Fall: 
                newSprite = fallSprite;
                break;
            case Season.Winter: 
                newSprite = winterSprite;
                break;
            case Season.Spring: 
                newSprite = springSprite;
                break;
            case Season.Summer: 
                newSprite = summerSprite;
                break;
            } 

        tileData.sprite = newSprite;
    }
}
    
