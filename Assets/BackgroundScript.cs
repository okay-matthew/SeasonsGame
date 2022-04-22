using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    [SerializeField]
    public Sprite fallSprite, winterSprite, springSprite, summerSprite, sprite;
    public SeasonManager season;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprite = gameObject.GetComponent<Sprite>();
        season = SeasonManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
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
