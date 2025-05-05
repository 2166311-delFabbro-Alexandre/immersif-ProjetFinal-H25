using UnityEngine;
using UnityEngine.InputSystem; // For input handling
using UnityEngine.XR.Interaction.Toolkit;
using Oculus.Interaction;

public class TirCanon : MonoBehaviour
{
    private GrabInteractable grabInteractable;
    private bool isGrabbed = false;

    [Header("Shooting Settings")]
    [SerializeField]
    public GameObject projectilePrefab;
    [SerializeField]
    public Transform firePoint1;
    [SerializeField]
    public Transform firePoint2;
    [SerializeField]
    public Transform firePoint3;
    [SerializeField]
    public Transform firePoint4;
    public float projectileForce = 12000f;

    [Header("Temps recharge")]
    [SerializeField]
    private float tirRecharge = 0.5f;
    private float dernierTir = 0f;

    private void Update()
    {
        if (Time.time >= dernierTir + tirRecharge)
        {
            Tir();
            dernierTir = Time.time;
        }
        
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }

    private bool IsTriggerPulled()
    {
        // Read input manually (left or right hand)
        var leftTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        var rightTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        // If either trigger is pressed over a threshold
        return leftTrigger > 0.8f || rightTrigger > 0.8f;
    }

    public void Tir()
    {
        if (projectilePrefab != null && firePoint1 != null && firePoint2 != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint1.position, firePoint1.rotation);
            GameObject projectile2 = Instantiate(projectilePrefab, firePoint2.position, firePoint2.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            Rigidbody rb2 = projectile2.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(firePoint1.forward * projectileForce, ForceMode.Impulse);
                rb2.AddForce(firePoint2.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }
}
