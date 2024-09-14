using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [ContextMenu("Go to hacking mini game")]
    public void GoToHackingMinigame()
    {
        SceneManager.LoadScene("HackingMinigame", LoadSceneMode.Single);
    }

    [ContextMenu("Quit Game")]
    public void QuitGame()
    {
        Application.Quit();
    }

    [ContextMenu("Go to main menu")]
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    [ContextMenu("Go to camera screen")]
    public void GoToCameraScreen()
    {
        SceneManager.LoadScene("Camera Screen", LoadSceneMode.Single);
    }

    [ContextMenu("Go to lose screen")]
    public void GoToLoseScreen()
    {
        SceneManager.LoadScene("AccessDenied", LoadSceneMode.Single);
    }

    [ContextMenu("Go to win screen")]
    public void GoToWinScreen()
    {
        SceneManager.LoadScene("AccessGranted", LoadSceneMode.Single);
    }

    [ContextMenu("Go to war screen")]
    public void GoToWarScreen()
    {
        SceneManager.LoadScene("WarScreen", LoadSceneMode.Single);
    }

    public IEnumerator GoToNextScene(string scene)
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}