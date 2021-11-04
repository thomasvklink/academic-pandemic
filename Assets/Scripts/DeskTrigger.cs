using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject script;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
          {
            Debug.Log("Entered desk");
            script.GetComponent<UIController>().DeskCheck(true);
          }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
          {
            Debug.Log("Left desk");
            script.GetComponent<UIController>().DeskCheck(false);
          }
    }
}
