using UnityEngine;
using UnityEngine.UI;

public class BackgroundCamera : MonoBehaviour
{
    public RawImage background;
    private WebCamTexture webCamTexture;

    void Start()
    {
        // Start the webcam
        webCamTexture = new WebCamTexture();
        background.texture = webCamTexture;  // Set the RawImage's texture to the webcam
        background.material.mainTexture = webCamTexture;  // You might not need this line, depending on your setup
        webCamTexture.Play();  // Start the camera
    }

    void OnDestroy()
    {
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}
