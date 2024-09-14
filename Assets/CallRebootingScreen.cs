using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallRebootingScreen : MonoBehaviour
{
    private SceneController sceneController;
    [SerializeField] float time;

    void Awake() {
        // Get scene controller info
        sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>(); 
    }

    void Start() {
        StartCoroutine(GoNext());
    }

    IEnumerator GoNext()
    {
        yield return new WaitForSeconds(time);

        sceneController.GoToClosingCutscene2();
    }
}
