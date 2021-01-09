using UnityEngine;

public class BlasterGun : MonoBehaviour
{
    [Header("Gun Settings")]
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.FireGun.performed += ctx => FireGun();
    }

    void FireGun()
    {
        Debug.Log("Trigger Pulled!!!");

        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);

        Debug.Log("Gun Fired!!!");
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
