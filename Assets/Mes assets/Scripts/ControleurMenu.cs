using UnityEngine;

/// <summary>
/// Classe pour contr�ler le menu du d�but
/// </summary>
public class ControleurMenu : MonoBehaviour
{
    // M�thode pour fermer le menu
    public void FermerMenu()
    {
        // Ferme le menu
        this.gameObject.SetActive(false);
    }

}
