using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComparePassword : MonoBehaviour
{
    private StringManager stringManager;
    private TMP_Text terminal;
    private string password;
    private string guess;
    private int similar;

    void Start() {
    }

    public void DoComparison() {
        // Get password
        stringManager = GameObject.FindWithTag("StringManager").GetComponent<StringManager>(); 
        password = stringManager.password;

        // Get guessed password
        guess = GetComponentInChildren<TMP_Text>().text;

        // Get terminal information
        terminal = GameObject.FindWithTag("Terminal").GetComponent<TMP_Text>(); 

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
        terminal.text += "\n> " + guess + "\n> Exact match! " + "\n> Infiltrating system...";
    }

    void IncorrectSequence() {
        terminal.text += "\n> " + guess + "\n> Incorrect! " + similar + " chars correct.";
    }
}
