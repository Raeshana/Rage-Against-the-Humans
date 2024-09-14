using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComparePassword : MonoBehaviour
{
    private StringManager stringManager;
    private string password;
    private string guess;

    void Start() {
    }

    public void DoComparison() {
        // Get password
        stringManager = GameObject.FindWithTag("StringManager").GetComponent<StringManager>(); 
        password = stringManager.password;

        // Get guessed password
        guess = GetComponentInChildren<TMP_Text>().text;

        // Correct password
        if (password == guess) {
            Debug.Log("yay!");
        }

        // Incorrect password
        else {
            int similar = 0;
            string shorter = password;
            if (guess.Length < password.Length) {
                shorter = guess;
            }

            for(int i = 0; i < shorter.Length; i++) {
                if (password[i] == guess[i]) {
                    similar++;
                } 
            }

            Debug.Log("pain " + similar);
        }
    }
}
