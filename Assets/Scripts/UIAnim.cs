using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAnim : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite[] spriteArr;
    [SerializeField] float speed;

    [SerializeField] TMP_Text text;
    [SerializeField] string[] lines;
    [SerializeField] int changeSpeed;

    private SceneController sceneController;

    void Awake() {
        // Get scene controller info
        sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>(); 
    }

    void Start() {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        foreach (Sprite sprite in spriteArr) {
            image.sprite = sprite;
            yield return new WaitForSeconds(speed);
        }

        foreach (string line in lines) {
            text.text = line;
            yield return new WaitForSeconds(changeSpeed);
        }

        if(gameObject.tag == "LastScene") {
            sceneController.GoToMainMenu();
        }
        else {
            sceneController.GoToCameraScreen();
        }
    }
}