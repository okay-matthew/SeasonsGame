using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager instance;

    [SerializeField]
    private int i = 0;
    [SerializeField]
    private string season = "fall";

    private List<string> seasonList = new List<string>() {"fall", "winter", "spring", "summer"};

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
        try
        {   
            season = seasonList[++i];
        }
        catch (System.Exception)
        {
            i = 0;
            season = seasonList[i];
        }
    }

    public string getSeason() {
        return season;
    }

}
