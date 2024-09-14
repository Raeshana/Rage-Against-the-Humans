using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AttemptManager : MonoBehaviour
{
    [HideInInspector]
    public int remAttempts;
    public int maxAttempts;

    public Image[] attempts;

    private TMP_Text terminal;
    [SerializeField] GameObject retryButtons;

    private SceneController sceneController;

    void Awake() {
        // Initialize remaining attempts
        remAttempts = maxAttempts;

        // Get terminal information
        terminal = GameObject.FindWithTag("Terminal").GetComponent<TMP_Text>(); 

        // Get scene controller information
        sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>(); 
    }

    void Update() {
        if (remAttempts <= 0) {
            Debug.Log("loser");
            sceneController.GoToLoseScreen();
        }
    }

    public void LoseAttempt() {
        remAttempts--;
        attempts[remAttempts].gameObject.SetActive(false);
    }
}
