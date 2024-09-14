using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComparePassword : MonoBehaviour
{
    private StringManager stringManager;
    private string password;
    private string guess;

    private TMP_Text terminal;
    private int similar;

    private AttemptManager attemptManager;

    private SceneController sceneController;

    void Awake() {
        // Get terminal information
        terminal = GameObject.FindWithTag("Terminal").GetComponent<TMP_Text>(); 

        // Get attempt manager information
        attemptManager = GameObject.FindWithTag("AttemptManager").GetComponent<AttemptManager>(); 

        // Get scene controller information
        sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>(); 
    }

    public void DoComparison() {
        // Get password
        stringManager = GameObject.FindWithTag("StringManager").GetComponent<StringManager>(); 
        password = stringManager.GetPassword();

        // Get guessed password
        guess = GetComponentInChildren<TMP_Text>().text;

        // Correct password
        if (password == guess) {
            CorrectSequence();
        }

        // Incorrect password
        else {
            similar = 0;
            string shorter = password;
            if (guess.Length < password.Length) {
                shorter = guess;
            }

            for(int i = 0; i < shorter.Length; i++) {
                if (password[i] == guess[i]) {
                    similar++;
                } 
            }

            IncorrectSequence();
        }
    }

    void CorrectSequence() {
        string lines = "\n> " + guess + "\n> Exact match!";
        stringManager.typingEffect.StartDialogue(terminal, lines);
        //terminal.text += "\n> " + guess + "\n> Exact match!";
        StartCoroutine(WinScreen());
    }

    IEnumerator WinScreen() {
        yield return new WaitForSeconds(0.3f);
        sceneController.GoToWinScreen();
    }

    void IncorrectSequence() {
        string lines = "\n> " + guess + "\n> Incorrect! " + similar + " chars correct.";
        stringManager.typingEffect.StartDialogue(terminal, lines);
        //terminal.text += "\n> " + guess + "\n> Incorrect! " + similar + " chars correct.";
        StartCoroutine(LoseScreen());
    }

    IEnumerator LoseScreen() {
        yield return new WaitForSeconds(0.3f);
        attemptManager.LoseAttempt();
    }
}
