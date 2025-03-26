using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//////////////////////////////////////////////
//Assignment/Lab/Project: Portal Project
//Name: Kristen Holcombe
//Section: SGD285.4173
//Instructor: Ven Lewis
//Date: 03/23/2025
////////////////////////////////////////////

public class ButtonScript : MonoBehaviour
{
    //level 1:
    //private GameObject portal1, door1, RedPortal1, RedDoor;
    //portal2, portal3, elevator, door1, door2, door3; 

    //Set target object and pickUp that triggers it
    [SerializeField] private GameObject targetObj;
    [SerializeField] private string pickUpName;

    [SerializeField] private Animator ButtonAnimator;
    [SerializeField] private Animator elevatorDoorAnim;
 
    //Later add a text obj with a rejection message if it doesn't work
    private void Start()
    {
       // targetObj.SetActive(false);
    }



    //each button is set to trigger a specific action when a pickup is placed on them based on name of button and name of button.
    private void OnTriggerEnter(Collider other)
    {
        print("entered collider");

        //room 1 button
        if (other.gameObject.name == pickUpName)
        {
            if (other.gameObject.name == "Elevator")
            {
                //plays elevator door anim
                elevatorDoorAnim.Play("door_2_open");
                //elevatorDoorAnim.Play("door_2_opened");
            }

            //print("gameObject.tag is" + gameObject.tag);
            //portal1.SetActive(true);
            targetObj.SetActive(true);
            print("portal Set Active");
            ButtonAnimator.Play("ButtonUpAnim");
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        print("exitted collider");

        //room 1 button
        if (other.gameObject.name == pickUpName)
        {
            //print("gameObject.tag is" + gameObject.tag);
            //portal1.SetActive(true);
            targetObj.SetActive(false);
            print("targetObj deactivated");
            ButtonAnimator.Play("ButtonDownAnim");
        }

    }

}

