using System;
using UnityEngine;

public class ControleCanon: MonoBehaviour
{
    [SerializeField]
    public Transform manetteCanon; // pour la rotation de la manette
    public Transform cannonTransform;

    public float maxPitchAngle = 30f;   // Max up/down movement
    public float maxYawAngle = 45f;     // Max left/right movement
    public float rotationSpeed = 5f;    // Smoothness of cannon rotation

    private Vector3 initialCannonRotation;

    void Start()
    {
        if (cannonTransform == null)
            cannonTransform = transform;

        // Save the starting rotation
        initialCannonRotation = cannonTransform.localEulerAngles;
    }

    void Update()
    {
        // Get stick tilt
        Vector3 localStickRotation = manetteCanon.localRotation.eulerAngles;

        // Fix weird Euler angles (>180)
        float stickX = (localStickRotation.x > 180) ? localStickRotation.x - 360 : localStickRotation.x;
        float stickZ = (localStickRotation.z > 180) ? localStickRotation.z - 360 : localStickRotation.z;

        // Map stick tilt to cannon movement
        float pitch = Mathf.Clamp(stickX, -maxPitchAngle, maxPitchAngle);
        float yaw = Mathf.Clamp(-stickZ, -maxYawAngle, maxYawAngle);

        // Target rotation
        Vector3 targetRotation = new Vector3(initialCannonRotation.x + pitch, initialCannonRotation.y + yaw, initialCannonRotation.z);

        // Smoothly rotate the cannon
        cannonTransform.localRotation = Quaternion.Lerp(cannonTransform.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
    }
}
