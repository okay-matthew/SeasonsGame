using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

 [CreateAssetMenu]
public class GrassTileData : Tile {

    public Tile[] tiles;

    public Sprite fallSprite, winterSprite, springSprite, summerSprite;

    void Update() {

    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref UnityEngine.Tilemaps.TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
         
            //    Change Sprite
            tileData.sprite = summerSprite;
    }

}
    
