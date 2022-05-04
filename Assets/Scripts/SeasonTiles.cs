using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
    Public class that creates a tile. Allows for properties of the tile to change with the season.

    Potential for sprite changes are coded in default. Any additional properties which change with the seasons must be added upon creating a unique
    instance of SeasonTile.
*/

 [CreateAssetMenu]
public class SeasonTiles : Tile { //TODO: we've gone waaay too far using the SeasonTiles with the 's'. Changeing it now would be a pain in the ass.

    public Sprite fallSprite, winterSprite, springSprite, summerSprite;
    public SeasonManager season;

    /*
        Overrides the GetTileData method. In order to change the tile sprites, we must access GetTileData while it runs.
        GetTileData runs whenever the tilemap the tile is on refreshes. So everytime the tilemap refreshes, it will check the season, and change the sprite 
        accordingly.
    */
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
    
