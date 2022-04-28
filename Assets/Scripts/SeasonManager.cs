using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager instance;
    
    [SerializeField]
    private Season season = Season.Fall;

    public static SeasonManager Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<SeasonManager>();
            }
            return instance;
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void changeSeason() {
        List<Season> allSeasons = new List<Season>((Season[]) Season.GetValues(typeof(Season)));
        int nextIndex = (allSeasons.IndexOf(season) + 1) % allSeasons.Count;
        season = allSeasons[nextIndex];
    }

    public Season getSeason() {
        return season;
    }

}
