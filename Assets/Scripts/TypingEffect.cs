using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    // public TextMeshProUGUI textComponent;
    // public string[] lines;
    public float textSpeed;

    // private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(TMP_Text textComponent, string lines) {
        StartCoroutine(TypeLine(textComponent, lines));
    }

    IEnumerator TypeLine(TMP_Text textComponent, string lines) {
        foreach (char c in lines.ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
