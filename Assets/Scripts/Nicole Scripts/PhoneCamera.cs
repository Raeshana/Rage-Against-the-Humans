using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class PhoneCamera : MonoBehaviour
{
    private WebCamTexture camTexture;
    public RawImage display;  // Assign this to a UI RawImage to see the camera feed
    public float requestInterval = 1f;  // Delay between each request (in seconds)
    public Button detectionButton;  // Button to show when an object is detected

    void Start()
    {
        camTexture = new WebCamTexture();
        display.texture = camTexture;
        camTexture.Play();  // Start the camera feed

        // Ensure the button is not visible at start
        detectionButton.gameObject.SetActive(false);

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
        UnityWebRequest request = UnityWebRequest.PostWwwForm("https://ccaa-34-173-106-55.ngrok-free.app/detect", UnityWebRequest.kHttpVerbPOST);
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
        Debug.Log("Processing detection data...");

        var detectionData = JSON.Parse(jsonResponse);
        if (detectionData.Count == 0)
        {
            Debug.Log("No objects detected.");
            detectionButton.gameObject.SetActive(false);  // Ensure button is hidden if no objects are detected
            return;
        }

        bool objectDetected = false;
        foreach (var detection in detectionData)
        {
            string detectedClass = detection.Value["class"];
            float confidence = detection.Value["confidence"].AsFloat;

            Debug.Log($"Detected: {detectedClass} with confidence {confidence}");

            if ((detectedClass == "cell phone" || detectedClass == "laptop") && confidence > 0.2) // Threshold confidence
            {
                objectDetected = true;
                break; // Assuming you only need one detection
            }
        }

        // Show or hide the button based on detection status
        detectionButton.gameObject.SetActive(objectDetected);
    }

    // Function to trigger the mini-game when a cell phone is detected
    void TriggerMiniGame()
    {
        Debug.Log("Cell phone detected! Triggering mini-game...");
        SceneManager.LoadScene("HackingMinigame");  // Load the mini-game scene
    }
}
