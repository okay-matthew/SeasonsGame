using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

 [CreateAssetMenu]
public class SeasonWaterTile : Tile {

    public Sprite fallSprite, winterSprite, springSprite, summerSprite;
    public SeasonManager season;

    bool winter;

    void Start() {
        winter = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
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
                winter = false;
                break;
            case Season.Winter: 
                newSprite = winterSprite;
                winter = true;
                break;
            case Season.Spring: 
                newSprite = springSprite;
                winter = false;
                break;
            case Season.Summer: 
                newSprite = summerSprite;
                winter = false;
                break;
            } 

        tileData.sprite = newSprite;
    }
}
