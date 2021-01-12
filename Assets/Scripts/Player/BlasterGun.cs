using UnityEngine;

public class BlasterGun : MonoBehaviour
{
    [Header("Gun Settings")]
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    AudioSource audioSource;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.FireGun.performed += ctx => FireGun();

        audioSource = GetComponent<AudioSource>();
    }

    void FireGun()
    {
        audioSource.Play();
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
