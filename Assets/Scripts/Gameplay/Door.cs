using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "Player")
       {
            if (PlayerController.instance.hasKeyCard == true)
            {
                animator.SetBool("OpenDoor", true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        animator.SetBool("OpenDoor", false);
    }
}
