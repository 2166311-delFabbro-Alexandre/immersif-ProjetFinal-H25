using UnityEngine;
using UnityEngine.Events;
using Meta.XR;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ControleGrabManette : XRGrabInteractable
{
    private Rigidbody rb;
    private ConfigurableJoint joint;
    private bool isGrabbed = false;
    private GrabInteractable grabInteractable;
    private Grabbable grabbable;
    public TirCanon tirCanon;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();

        if(rb == null)
        {
            Debug.LogError("Rigidbody not found on the object.");
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (rb != null)
        {
            rb.isKinematic = false; // Allow physical movement
        }

            tirCanon.Tir(); 
        
        Debug.Log("Hand grabbed the object: " + gameObject.name);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (rb != null)
        {
            rb.isKinematic = true; // Lock physics
        }

        Debug.Log("Hand released the object: " + gameObject.name);
    }
}
