using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateString : MonoBehaviour
{
    [SerializeField] StringSet stringSet;
    private int size;

    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();

        foreach (string s in stringSet.strings) {
            size++;
        }

        int randNum = Random.Range(0, size-1);

        text.text = stringSet.strings[randNum];
    }
}
