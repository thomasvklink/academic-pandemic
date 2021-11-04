using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    
    public GameObject CameraMount;
    public GameObject TargetObject;
    float angle;
    public float speed;

    public GameObject Angle1;
    public GameObject Angle2;
    public GameObject Angle3;
    public GameObject Angle4;

    void Start()
    {
        angle = 0;
        Angle1.SetActive(true);
        Angle2.SetActive(true);
        Angle3.SetActive(false);
        Angle4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Q)) //Thanks to Jesse
        {
            //Rotate TargetObject into direction players want to move to
            TargetObject.transform.Rotate(Vector3.up * 90);
        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            //Rotate TargetObject into direction players want to move to
            TargetObject.transform.Rotate(-Vector3.up * 90);
        }

        //Smoothly rotate CameraMount towards TargetObject
        transform.rotation = Quaternion.Slerp(transform.rotation, TargetObject.transform.rotation, speed*Time.deltaTime);
        
        //Update walls
        Show();
    }

    // Use the rotation of the camera object to determine what side your are on and change the sides accordingly

    void Show()
    {
        angle = TargetObject.transform.rotation.eulerAngles.y;
        //Debug.Log(angle);

        if(angle == 0)
        {
            Angle1.SetActive(true);
            Angle2.SetActive(true);
            Angle3.SetActive(false);
            Angle4.SetActive(false);
        } 
        else if (angle == 90)
        {
            Angle1.SetActive(true);
            Angle2.SetActive(false);
            Angle3.SetActive(true);
            Angle4.SetActive(false);
        } 
        else if (angle == 180)
        {
            Angle1.SetActive(false);
            Angle2.SetActive(false);
            Angle3.SetActive(true);
            Angle4.SetActive(true);
        } 
       else if (angle == 270)
        {
            Angle1.SetActive(false);
            Angle2.SetActive(true);
            Angle3.SetActive(false);
            Angle4.SetActive(true);
        }
    }
}
