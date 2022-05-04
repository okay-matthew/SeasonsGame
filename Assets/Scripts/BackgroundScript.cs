using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Script for the background image to each level
*/

public class BackgroundScript : MonoBehaviour
{

    [SerializeField]
    public Sprite fallSprite, winterSprite, springSprite, summerSprite, sprite;
    public SeasonManager season;
    public Season previousSeason;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprite = gameObject.GetComponent<Sprite>(); //allows us to change the backgrounds sprite
        season = SeasonManager.Instance;
    }

    void Update()
    {
        if (previousSeason == season.getSeason()) { //only changes seasons when a different season from the last update
            SeasonChange();                         // is detected
        }
        previousSeason = season.getSeason();
    }
    
    /*
    Changes sprite when the season changes.
    */
    void SeasonChange() {
        switch (season.getSeason()) {
            case Season.Fall: 
                sprite = fallSprite;
                break;
            case Season.Winter: 
                sprite = winterSprite;
                break;
            case Season.Spring: 
                sprite = springSprite;
                break;
            case Season.Summer: 
                sprite = summerSprite;
                break;
            } 
        spriteRenderer.sprite = sprite;
    }
}
