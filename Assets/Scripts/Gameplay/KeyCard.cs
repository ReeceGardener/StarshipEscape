using UnityEngine;

public class KeyCard : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.instance.hasKeyCard = true;
            Destroy(gameObject);
        }
    }
}
