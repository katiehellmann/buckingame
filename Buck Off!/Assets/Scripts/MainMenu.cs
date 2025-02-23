using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelOne;
    public GameObject creditsScreen;

    // Start game with delay
    public void StartGame()
    {
        StartCoroutine(LoadLevelWithDelay());
    }

    private IEnumerator LoadLevelWithDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelOne);
    }

    // Open credits function
    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    // Close credits function
    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
    }

    // Quit game function
    public void QuitGame()
    {
        Application.Quit();
    }
}