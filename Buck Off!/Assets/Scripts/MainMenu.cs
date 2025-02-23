using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelOne;
    public GameObject creditsScreen;

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
}