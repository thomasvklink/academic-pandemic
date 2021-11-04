//Based on code from Studica News (https://www.youtube.com/watch?v=XhliRnzJe5g&ab_channel=StudicaNews)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   Animator animator;
    public GameObject Camera;

    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward,right;

    void Start()
    {
        Angle(); //Set the camera angle for player movement at start of the game (standard view, 45 deg);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Angle(); //Update the angle on key press as the view might have been rotated by the player.
            Move(); //Then move the player according to the camera angle.
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //Apply movement to the vector
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    void Angle()
    {
        //Define angle from the current camera
        forward = Camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }
}
