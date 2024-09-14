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

    private TypingEffect typingEffect;

    void Awake() {
        // Get terminal information
        terminal = GameObject.FindWithTag("Terminal").GetComponent<TMP_Text>(); 

        // Get attempt manager information
        attemptManager = GameObject.FindWithTag("AttemptManager").GetComponent<AttemptManager>(); 

        // Get scene controller information
        sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>(); 

        // Get typing effect info
        typingEffect = GameObject.FindWithTag("StringManager").GetComponent<TypingEffect>(); 
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
        typingEffect.StartDialogue(terminal, lines);
        StartCoroutine(WinScreen());
    }

    IEnumerator WinScreen() {
        yield return new WaitForSeconds(2f);
        sceneController.GoToWinScreen();
    }

    void IncorrectSequence() {
        string lines = "\n> " + guess + "\n> Incorrect! " + similar + " chars correct.";
        typingEffect.StartDialogue(terminal, lines);
        attemptManager.LoseAttempt();
    }
}
