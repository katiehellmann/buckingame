using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //script to switch between scenes 


    public string levelOne;
    public GameObject creditsScreen;
    public string startScreen;
    public string instructionsScreen;
    public string failScreen;


    //delaaayyyyy
    public void StartGame()
    {
        StartCoroutine(LoadLevelWithDelay());
    }

    private IEnumerator LoadLevelWithDelay()
    {
        //1.5 second buffer
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelOne);
    }

    private IEnumerator LoadInstrucWithDelay()
    {
        //1.5 second buffer
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(instructionsScreen);
    }

    //open creds
    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    //close creds
    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
    }

    //quit
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartingScene()
    {
        SceneManager.LoadScene(startScreen);
    }


    //instructions
    // Open instructions scene
    public void OpenInstructions()
    {
        StartCoroutine(LoadInstrucWithDelay());
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene(failScreen);
    }
}