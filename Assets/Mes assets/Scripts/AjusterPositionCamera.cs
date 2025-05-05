using UnityEngine;

/**
 * Ajuste la position de la cam�ra pour qu'elle soit � la hauteur du si�ge.
 * Attach� � la cam�ra.
 * 
 * @author - Alexandre del Fabbro
 * Inspir� du code de OpenAi - ChatGPT [Mod�le massif de langage] - [https://openai.com/] - [Consult� le 25 avril 2025]
 */
public class AjusterPositionCamera : MonoBehaviour
{
    // Transform du si�ge
    public Transform positionCamera;


    void Start()
    {
        // Active le mode EyeLevel pour la position assise
        if (OVRManager.instance != null)
        {
            OVRManager.instance.trackingOriginType = OVRManager.TrackingOrigin.EyeLevel;
        }

        // Place le rig � la position du si�ge
        transform.position = positionCamera.position;
        transform.rotation = positionCamera.rotation; // Optionnel : aligne la vue
    }
}
