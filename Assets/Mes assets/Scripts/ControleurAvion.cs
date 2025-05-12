using UnityEngine;

/// <summary>
/// Classe permettant de faire voler un avion.
/// </summary>
public class ControleurAvion : MonoBehaviour
{
    // Références et paramètres des composants pour le vol
    [SerializeField]

    // Vitesse de l'avion
    private float vitesseAvion = 50f;

    // Référence au Rigidbody de l'avion
    private Rigidbody rbAvion;

    // Booléen pour savoir si l'avion est entrain de s'écraser
    private bool avionEcrase = false;

    private void Start()
    {
        // Récupération du Rigidbody de l'avion
        rbAvion = GetComponent<Rigidbody>();
        // Vérification de la présence du Rigidbody
        if (rbAvion == null)
        {
            Debug.LogError("Le Rigidbody de l'avion n'a pas été trouvé !");
            return;
        }
        // Vérification que le kinematic est activé
        rbAvion.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérification si l'objet qui entre en collision est la balle
        if (other.CompareTag("Balle"))
        {
            // Appel de la méthode pour déclencher l'écrasement
            DeclencherEcrasement();
        }
    }
    /// <summary>
    /// Méthode pour déclencher l'écrasement de l'avion.
    /// </summary>
    public void DeclencherEcrasement()
    {
        if (avionEcrase) return;

        avionEcrase = true;

        rbAvion.isKinematic = false;
        rbAvion.useGravity = true;

        rbAvion.AddForce(Vector3.down * 10f, ForceMode.Impulse);
        rbAvion.AddTorque(Random.onUnitSphere * 20f, ForceMode.Impulse);
    }

    


    void Update()
    {
        if (avionEcrase) return;
        // Calcul pour le mouvement de l'avion
        transform.position += -transform.right * vitesseAvion * Time.deltaTime;
    }
}
