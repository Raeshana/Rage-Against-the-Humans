using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;
using System.Linq;

public class StringManager : MonoBehaviour
{
    [SerializeField] TMP_Text[] wordsArr;
    private List<string> words = new List<string>();

    [HideInInspector]
    private string password;
 
    // Start is called before the first frame update
    void Start()
    {
        NoDupes(); // Ensure there are no duplicate strings in the terminal

        // Randomly choose a word from words to be the password
        GeneratePassword();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool AtLeastOne() {
        foreach (string word in words) {
            foreach(string compWord in words) {
                string shorter = word;
                if (compWord.Length < shorter.Length) {
                    shorter = compWord;
                }
                for (int i = 0; i < shorter.Length; i++) {
                    if (word[i] == compWord[i]) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    void NoDupes() {
        foreach (TMP_Text text in wordsArr) {
            string word = text.text;
            while (words.Contains(word)) {
                text.transform.parent.GetComponent<GenerateString>().AssignString();
                word = text.text;
            }
            words.Add(text.text);
        }
    }

    void GeneratePassword() {
        password = words[GetRandNum()];
        Debug.Log(password);

        foreach (string word in words) {
            if (word != password) {
                string shorter = password;
                if (word.Length < shorter.Length) {
                    shorter = word;
                }
                for (int i = 0; i < shorter.Length; i++) {
                    if (password[i] == word[i]) {
                        Debug.Log(word);
                        return;
                    };
                }
            }
        }

        GeneratePassword();
    }

    int GetRandNum() {
        return Random.Range(0, wordsArr.Length-1);
    }

    public string GetPassword() {
        return password;
    }
}
