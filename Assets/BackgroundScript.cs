using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        sprite = gameObject.GetComponent<Sprite>();
        season = SeasonManager.Instance;
    }

    void Update()
    {
        if (previousSeason == season.getSeason()) {
            SeasonChange();
        }
        previousSeason = season.getSeason();
    }

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
