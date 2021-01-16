using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        // Gets the animator for the door
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Checks object that has collided is the player and if the player has the key card
        if (collision.gameObject.tag == "Player" && PlayerController.instance.hasKeyCard == true)
        {
            /* Sets OpenDoor boolean to true, so in the door's 
             * animator will play the door open animation */
            animator.SetBool("OpenDoor", true);
        }
    }

    // 
    private void OnTriggerExit(Collider collision)
    {
        /* Sets OpenDoor boolean to false, so in the door's 
         * animator will play the door close animation */
        animator.SetBool("OpenDoor", false);
    }
}
