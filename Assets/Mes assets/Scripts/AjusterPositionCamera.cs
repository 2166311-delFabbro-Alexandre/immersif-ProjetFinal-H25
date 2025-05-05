using UnityEngine;

/**
 * Ajuste la position de la caméra pour qu'elle soit à la hauteur du siège.
 * Attaché à la caméra.
 * 
 * @author - Alexandre del Fabbro
 * Inspiré du code de OpenAi - ChatGPT [Modèle massif de langage] - [https://openai.com/] - [Consulté le 25 avril 2025]
 */
public class AjusterPositionCamera : MonoBehaviour
{
    // Transform du siège
    public Transform positionCamera;


    void Start()
    {
        // Active le mode EyeLevel pour la position assise
        if (OVRManager.instance != null)
        {
            OVRManager.instance.trackingOriginType = OVRManager.TrackingOrigin.EyeLevel;
        }

        // Place le rig à la position du siège
        transform.position = positionCamera.position;
        transform.rotation = positionCamera.rotation; // Optionnel : aligne la vue
    }
}
