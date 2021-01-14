using UnityEngine;

public class BlasterGun : MonoBehaviour
{
    public static BlasterGun instance { set; get; }

    [Header("Gun Settings")]
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public int currentAmmo = 20;
    public int maxAmmo = 20;

    AudioSource audioSource;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.FireGun.performed += ctx => FireGun();

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void FireGun()
    {
        if (currentAmmo >= 1)
        {
            audioSource.Play();
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
            currentAmmo -= 1;
        }
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
