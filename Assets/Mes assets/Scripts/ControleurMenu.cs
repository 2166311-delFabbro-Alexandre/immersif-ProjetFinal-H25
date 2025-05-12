using UnityEngine;

/// <summary>
/// Classe pour contrôler le menu du début
/// </summary>
public class ControleurMenu : MonoBehaviour
{
    // Méthode pour fermer le menu
    public void FermerMenu()
    {
        // Ferme le menu
        this.gameObject.SetActive(false);
    }

}
