using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject detectionPopupPanel;  // Reference to the detection popup panel
    public Text objectNameText;             // Reference to the object name text in the popup
    public GameObject hackDevicePanel;      // Reference to the Hack Device? popup
    public Button yesButton;                // Reference to the Yes button
    public Button noButton;                 // Reference to the No button

    private string detectedObjectName;

    void Start()
    {
        // Initially hide both panels
        detectionPopupPanel.SetActive(false);
        hackDevicePanel.SetActive(false);

        // Add listeners for Yes/No buttons
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    // Call this when an object (like phone/computer) is detected
    public void ShowObjectDetected(string objectName)
    {
        detectedObjectName = objectName;  // Store the detected object's name

        // Update the text to display the detected object's name
        objectNameText.text = "Detected: " + objectName;

        // Show the detection popup panel
        detectionPopupPanel.SetActive(true);
    }

    // Call this to show the "Hack Device?" popup
    public void ShowHackPrompt()
    {
        // Hide the detection popup panel and show the hack device panel
        detectionPopupPanel.SetActive(false);
        hackDevicePanel.SetActive(true);
    }

    // Called when the Yes button is clicked
    void OnYesButtonClicked()
    {
        Debug.Log("Yes button clicked! Starting mini-game...");
        
        // Hide the hack device panel and trigger the mini-game
        hackDevicePanel.SetActive(false);
        TriggerMiniGame();  // Call your mini-game logic here
    }

    // Called when the No button is clicked
    void OnNoButtonClicked()
    {
        Debug.Log("No button clicked! Dismissing...");
        // Just hide the hack device panel
        hackDevicePanel.SetActive(false);
    }

    // Your mini-game trigger logic here
    void TriggerMiniGame()
    {
        // Call the mini-game logic (could be loading a new scene or starting a mini-game UI)
        SceneManager.LoadScene("MiniGameScene");  // Example: load the mini-game scene
    }
}
