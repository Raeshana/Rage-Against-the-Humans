using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CRTCameraBehaviour : MonoBehaviour {
    public Material crtMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        if (crtMaterial != null) {
            Graphics.Blit(src, dest, crtMaterial);
        } else {
            Graphics.Blit(src, dest);
        }
    }
}