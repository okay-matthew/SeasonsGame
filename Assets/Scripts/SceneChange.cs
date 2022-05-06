using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour

/*
    Script for changing the scenes.
*/

{
    public void LoadGame() 
    {
        SceneManager.LoadScene("level-1");
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit!"); //TODO: make this actually quit the .exe
    }
}
