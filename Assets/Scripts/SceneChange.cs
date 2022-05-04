using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour

{
    public void LoadGame() 
    {
        SceneManager.LoadScene("testing");
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit!"); //TODO: make this actually quit the .exe
    }
}
