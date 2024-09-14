using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateString : MonoBehaviour
{
    [SerializeField] StringSet[] stringSetArr;
    private StringSet stringSet;
    private int size;

    private TMP_Text text;

    // Start is called before the first frame update
    void Awake()
    {
        AssignString(); // Assigns a random string from the string pool to the TMP_Text
    }

    public void AssignString() {
        text = GetComponentInChildren<TMP_Text>();

        GetString();

        text.text = stringSet.strings[GetRandNum()];
    }

    void GetString() {
        if (gameObject.tag == "1-char") stringSet = stringSetArr[0];
        if (gameObject.tag == "2-char") stringSet = stringSetArr[1];
        if (gameObject.tag == "3-char") stringSet = stringSetArr[2];
        if (gameObject.tag == "4-char") stringSet = stringSetArr[3];
        if (gameObject.tag == "5-char") stringSet = stringSetArr[4];
        if (gameObject.tag == "6-char") stringSet = stringSetArr[5];
        if (gameObject.tag == "7-char") stringSet = stringSetArr[6];
        if (gameObject.tag == "8-char") stringSet = stringSetArr[7];
    }

    int GetRandNum() {
        return Random.Range(0, stringSet.strings.Length-1);
    }
}
