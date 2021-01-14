using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    int ammoAmount;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (BlasterGun.instance.currentAmmo != BlasterGun.instance.maxAmmo && PlayerController.instance.health != 0)
            {
                ammoAmount = BlasterGun.instance.maxAmmo - BlasterGun.instance.currentAmmo;
                BlasterGun.instance.currentAmmo += ammoAmount;
                Destroy(gameObject);
            }
        }
    }
}
