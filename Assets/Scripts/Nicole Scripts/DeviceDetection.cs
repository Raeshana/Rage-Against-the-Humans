using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;
using UnityEngine.SceneManagement;
using TMPro;

public class DeviceDetection : MonoBehaviour
{
    private WebCamTexture camTexture;
    public RawImage display;  // Assign this to a UI RawImage to see the camera feed
    public float requestInterval = 1f;  // Delay between each request (in seconds)
    public GameObject Popup;  // Reference to the entire Popup GameObject
    public Button detectionButton;  // Reference to the Button inside the Popup
    public TMP_Text deviceName;


    void Start()
    {
        camTexture = new WebCamTexture();
        display.texture = camTexture;
        camTexture.Play();  // Start the camera feed

        Popup.SetActive(false);  // Hide the popup initially

        // detectionButton.onClick.AddListener(TriggerMiniGame);  // Ensure button click triggers the mini-game

        // Start sending frames with a delay between requests
        StartCoroutine(SendImageRoutine());
    }


    IEnumerator SendImageRoutine()
    {
        while (true)
        {
            // Capture the camera frame
            Texture2D snap = new Texture2D(camTexture.width, camTexture.height);
            snap.SetPixels(camTexture.GetPixels());
            snap.Apply();

            // Convert the Texture2D to a byte array
            byte[] imageBytes = snap.EncodeToJPG();

            // Send the imageBytes to the Flask server for object detection
            yield return StartCoroutine(SendImageToFlask(imageBytes));

            // Wait for a set interval before sending the next request (reduce rate)
            yield return new WaitForSeconds(requestInterval);
        }
    }

    IEnumerator SendImageToFlask(byte[] imageBytes)
    {
        // Make a POST request to send the image
        UnityWebRequest request = UnityWebRequest.PostWwwForm("https://5f33-34-70-175-72.ngrok-free.app/detect", UnityWebRequest.kHttpVerbPOST);
        request.uploadHandler = new UploadHandlerRaw(imageBytes);
        request.SetRequestHeader("Content-Type", "application/octet-stream");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Received object detection response: " + request.downloadHandler.text);
            ProcessDetectionData(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error sending image: " + request.error);
        }
    }

    void ProcessDetectionData(string jsonResponse)
    {
        var detectionData = JSON.Parse(jsonResponse);
        if (detectionData.Count == 0)
        {
            Debug.Log("No objects detected.");
            Popup.SetActive(false);
            detectionButton.gameObject.SetActive(false);
            return;
        }

        foreach (var detection in detectionData)
        {
            string detectedClass = detection.Value["class"];
            float confidence = detection.Value["confidence"].AsFloat;

            if ((detectedClass == "cell phone" || detectedClass == "laptop") && confidence > 0.2) // Threshold confidence
            {
                Popup.SetActive(true);  // Show the popup
                detectionButton.gameObject.SetActive(true);
                deviceName.text = detectedClass;
                break;
            }
        }
    }

    // Function to trigger the mini-game when a cell phone is detected
    // void TriggerMiniGame()
    // {
    //     Debug.Log("Triggering mini-game...");
    //     SceneManager.LoadScene("HackingMinigame");  // Make sure this is the correct scene name
    // }
}
