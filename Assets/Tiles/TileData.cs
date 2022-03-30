using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

 [CreateAssetMenu]
public class TileData : ScriptableObject
{

    public TileBase[] tiles;

    public bool fall, winter, spring, summer;

    public Sprite fallSprite, winterSprite, springSprite, summerSprite;
    
}

