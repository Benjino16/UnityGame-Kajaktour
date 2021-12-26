using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("Loading game...");
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quited application and stopped player mode in Testframework");
    }
}
