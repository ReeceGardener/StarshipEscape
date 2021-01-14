using UnityEngine;

public class HealthPack : MonoBehaviour
{
    float heathAmount;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerController.instance.health != PlayerController.instance.maxHealth && PlayerController.instance.health != 0)
            {
                heathAmount = PlayerController.instance.maxHealth - PlayerController.instance.health;
                PlayerController.instance.health += heathAmount;
                Destroy(gameObject);
            }
        }
    }
}
