using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public GameObject script;
    public Animator animator;
    public bool Sleeping = false;
    public bool Deskcheck = false;
    [SerializeField] TextMeshProUGUI SleepText;
    [SerializeField] TextMeshProUGUI LaptopText;
    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            popUpBox.SetActive(true);
            SleepText.text = ("Go to bed? Press Enter");
            animator.SetBool("Pop", true);
/*            if (Input.GetKey(KeyCode.Return))
            {
                animator.SetBool("Sleeping", true);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                animator.SetBool("Sleeping", false);
            }*/
            if (Deskcheck == true)
            {
                popUpBox.SetActive(true);
                LaptopText.text = ("Start up Laptop? Press Enter");
                animator.SetBool("Pop", true);
            }
        }
    }
    public void ComputerCheck(bool status)
    {
        Deskcheck = status;
    }
    public void OnTriggerExit(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            popUpBox.SetActive(false);
            SleepText.text = ("Go to bed? Press Enter");
            animator.SetBool("Pop", false);
            if (Deskcheck == false)
            {
                popUpBox.SetActive(false);
                LaptopText.text = ("Start up Laptop? Press Enter");
                animator.SetBool("Pop", false);
            }
        }
    }
}
