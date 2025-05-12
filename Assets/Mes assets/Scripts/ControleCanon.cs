using System;
using UnityEngine;

/// <summary>
/// Classe permettant de contrôler la rotation du canon.
/// 
/// Auteur: Alexandre del Fabbro
/// Inspiré du code d'OpenAi - ChatGPT - [Modèle massif de langage] - chat.openai.com - [Consulté le 28 avril 2025]
/// </summary>
public class ControleCanon: MonoBehaviour
{
    
    [SerializeField]
    // La manette de contrôle du canon
    public Transform manetteCanon;
    // Le canon à contrôler
    public Transform cannonTransform;

    [Header("Paramètres de rotation")]
    public float maxAngleHautBas = 45f;
    public float maxAngleGaucheDroite = 45f;
    public float vitesseRotation = 5f;

    private Vector3 rotationInitialeCanon;

    void Start()
    {
        // Le transform du canon
        cannonTransform = transform;

        // La rotation initiale du canon
        rotationInitialeCanon = cannonTransform.localEulerAngles;
    }

    void Update()
    {
        // Récupérer la rotation de la manette
        Vector3 localStickRotation = manetteCanon.localRotation.eulerAngles;

        // Convertir les angles de rotation de 0-360 à -180-180
        float stickX = (localStickRotation.x > 180) ? localStickRotation.x - 360 : localStickRotation.x;
        float stickZ = (localStickRotation.z > 180) ? localStickRotation.z - 360 : localStickRotation.z;

        // Assigner les angles de rotation du canon
        float pitch = Mathf.Clamp(stickX, -maxAngleHautBas, maxAngleHautBas);
        float yaw = Mathf.Clamp(-stickZ, -maxAngleGaucheDroite, maxAngleGaucheDroite);

        // La rotation cible du canon
        Vector3 targetRotation = new Vector3(rotationInitialeCanon.x + pitch, rotationInitialeCanon.y + yaw, rotationInitialeCanon.z);

        // Rotation du canon par rapport à la vitesse de rotation
        cannonTransform.localRotation = Quaternion.Lerp(cannonTransform.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * vitesseRotation);
    }
}
