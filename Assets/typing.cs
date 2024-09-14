using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typing : MonoBehaviour
{
    private TypingEffect typingEffect;
    private TMP_Text terminal;
    private string lines;

    void Awake() {
        // Get typing effect info
        typingEffect = GameObject.FindWithTag("StringManager").GetComponent<TypingEffect>(); 

        terminal = gameObject.GetComponent<TMP_Text>();
        lines = terminal.text; 
        terminal.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        typingEffect.StartDialogue(terminal, lines);
    }
}
