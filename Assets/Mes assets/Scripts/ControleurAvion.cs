using UnityEngine;

/// <summary>
/// Classe permettant de faire voler un avion.
/// </summary>
public class ControleurAvion : MonoBehaviour
{
    // R�f�rences et param�tres des composants pour le vol
    [SerializeField]

    // Vitesse de l'avion
    private float vitesseAvion = 50f;

    // R�f�rence au Rigidbody de l'avion
    private Rigidbody rbAvion;

    // Bool�en pour savoir si l'avion est entrain de s'�craser
    private bool avionEcrase = false;

    private void Start()
    {
        // R�cup�ration du Rigidbody de l'avion
        rbAvion = GetComponent<Rigidbody>();
        // V�rification de la pr�sence du Rigidbody
        if (rbAvion == null)
        {
            Debug.LogError("Le Rigidbody de l'avion n'a pas �t� trouv� !");
            return;
        }
        // V�rification que le kinematic est activ�
        rbAvion.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rification si l'objet qui entre en collision est la balle
        if (other.CompareTag("Balle"))
        {
            // Appel de la m�thode pour d�clencher l'�crasement
            DeclencherEcrasement();
        }
    }
    /// <summary>
    /// M�thode pour d�clencher l'�crasement de l'avion.
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
