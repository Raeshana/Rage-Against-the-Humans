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
    [SerializeField] private GameObject detectionMarker;  // UI element to point to detected objects

    void Start()
    {
        camTexture = new WebCamTexture();
        display.texture = camTexture;
        camTexture.Play();  // Start the camera feed

        // Ensure the marker is not visible at start
        detectionMarker.SetActive(false);

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
            return;
        }

        foreach (var detection in detectionData)
        {
            string detectedClass = detection.Value["class"];
            float confidence = detection.Value["confidence"].AsFloat;
            JSONArray bbox = detection.Value["bbox"].AsArray;

            // Bounding box format usually is [x1, y1, x2, y2]
            float x = bbox[0].AsFloat;
            float y = bbox[1].AsFloat;
            float width = bbox[2].AsFloat - x;
            float height = bbox[3].AsFloat - y;

            Debug.Log($"Detected: {detectedClass} with confidence {confidence}");

            if ((detectedClass == "cell phone" || detectedClass == "laptop") && confidence > 0.2) // Threshold confidence
            {
                PositionDetectionMarker(x, y, width, height);
                break; // Assuming you only need one detection
            }
        }
    }

    void PositionDetectionMarker(float x, float y, float width, float height)
    {
        // Convert bounding box coordinates from detection scale to screen scale
        RectTransform canvasRect = display.canvas.GetComponent<RectTransform>();

        // Calculate position on the canvas
        float xMin = x / camTexture.width * canvasRect.sizeDelta.x;
        float yMin = (1 - (y + height) / camTexture.height) * canvasRect.sizeDelta.y;
        float markerWidth = width / camTexture.width * canvasRect.sizeDelta.x;
        float markerHeight = height / camTexture.height * canvasRect.sizeDelta.y;

        // Set the position and size of your marker (e.g., an arrow or rectangle image)
        RectTransform markerRect = detectionMarker.GetComponent<RectTransform>();
        markerRect.anchoredPosition = new Vector2(xMin + markerWidth / 2, yMin + markerHeight / 2);
        markerRect.sizeDelta = new Vector2(markerWidth, markerHeight);

        // Optionally, make the marker visible if previously hidden
        detectionMarker.SetActive(true);
    }

    // Function to trigger the mini-game when a cell phone is detected
    void TriggerMiniGame()
    {
        Debug.Log("Cell phone detected! Triggering mini-game...");
        SceneManager.LoadScene("HackingMinigame");  // Load the mini-game scene
    }
}
