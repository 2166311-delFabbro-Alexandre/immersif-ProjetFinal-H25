using UnityEngine;
using UnityEngine.InputSystem; // For input handling
using UnityEngine.XR.Interaction.Toolkit;
using Oculus.Interaction;

/// <summary>
/// Classe permettant au joueur de tirer des projectiles depuis le canon.
/// 
/// Auteur: Alexandre del Fabbro
/// </summary>
public class TirCanon : MonoBehaviour
{
    // R�f�rences  et param�tres des composants pour le tir
    [Header("Param�tres tir")]

    // Pr�fab du projectile � tirer
    [SerializeField]
    public GameObject projectilePrefab;

    // R�f�rences aux points de tir et audio
    [SerializeField]
    public Transform firePoint1;
    public AudioSource point1Audio;
    [SerializeField]
    public Transform firePoint2;
    public AudioSource point2Audio;
    [SerializeField]
    public Transform firePoint3;
    public AudioSource point3Audio;
    [SerializeField]
    public Transform firePoint4;
    public AudioSource point4Audio;

    // Force d'impulsion du projectile
    [SerializeField]
    public float projectileForce = 1000f;

    // Temps de recharge entre les tirs
    [SerializeField]
    private float tirRecharge = 0.05f;

    // Minuteur de tir
    private float dernierTir = 0f;

    private void Awake()
    {
        point1Audio = firePoint1.GetComponent<AudioSource>();
        point2Audio = firePoint2.GetComponent<AudioSource>();
    }
    private void Update()
    {
        // Tir si le temps de recharge est �coul�
        if (Time.time >= dernierTir + tirRecharge)
        {
            Tir();
            dernierTir = Time.time;
        }
        
    }

    /// <summary>
    /// Tire un projectile depuis le canon.
    /// </summary>
    public void Tir()
    {
        // V�rifie si le prefab du projectile et les points de tir sont assign�s
        if (projectilePrefab != null && firePoint1 != null && firePoint2 != null)
        {
            // Instancie les projectiles aux points de tir
            GameObject projectile = Instantiate(projectilePrefab, firePoint1.position, firePoint1.rotation);
            GameObject projectile2 = Instantiate(projectilePrefab, firePoint2.position, firePoint2.rotation);

            // Les rigidbodies des projectiles
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            Rigidbody rb2 = projectile2.GetComponent<Rigidbody>();

            // V�rifie si les rigidbodies existent
            if (rb != null && rb2 !=null)
            {
                // Applique une force d'impulsion aux projectiles
                rb.AddForce(firePoint1.forward * projectileForce, ForceMode.Impulse);
                rb2.AddForce(firePoint2.forward * projectileForce, ForceMode.Impulse);

                // Joue le son de tir
                point1Audio.Play();
                point2Audio.Play();

                // D�truit les projectiles apr�s 3 secondes
                Destroy(rb.gameObject, 3f);
                Destroy(rb2.gameObject, 3f);
            }
        }
    }
}
