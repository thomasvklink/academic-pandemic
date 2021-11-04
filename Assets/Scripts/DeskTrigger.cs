using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject script;
    public GameObject script2;
    public GameObject script3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
          {
            Debug.Log("Entered desk");
            script.GetComponent<UIController>().DeskCheck(true);
            script2.GetComponent<Sliders>().ComputerCheck(true);
            script3.GetComponent<PopUpSystem>().ComputerCheck(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
          {
            Debug.Log("Left desk");
            script.GetComponent<UIController>().DeskCheck(false);
            script2.GetComponent<Sliders>().ComputerCheck(false);
            script3.GetComponent<PopUpSystem>().ComputerCheck(false);
        }
    }
}
