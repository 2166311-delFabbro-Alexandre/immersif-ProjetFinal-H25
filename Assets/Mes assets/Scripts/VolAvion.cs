using UnityEngine;

/// <summary>
/// Classe permettant de faire voler un avion.
/// </summary>
public class VolAvion : MonoBehaviour
{
    // Références et paramètres des composants pour le vol
    [SerializeField]
    private float vitesseAvion = 50f; 

    // Update is called once per frame
    void Update()
    {
        // Calcul pour le mouvement de l'avion
        transform.position += -transform.right * vitesseAvion * Time.deltaTime;
    }
}
