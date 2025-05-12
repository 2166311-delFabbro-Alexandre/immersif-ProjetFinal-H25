using UnityEngine;

/// <summary>
/// Classe pour g�rer le comportement de la balle.
/// 
/// Auteur: Alexandre del Fabbro
/// </summary>
public class Balle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ControleurAvion controleurAvion = other.GetComponentInParent<ControleurAvion>();

        if (controleurAvion != null)
        {
            controleurAvion.DeclencherEcrasement();
        }
    }
}
