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
    private Animator elevatorDoorAnim;
 
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
            ButtonAnimator.Play("ButtonDownAnim");
            ButtonAnimator.Play("ButtonPressedAnim");

            if (other.gameObject.name == "Elevator")
            {
                GameObject elevator = GameObject.Find("Elevator");
                elevatorDoorAnim = elevator.GetComponent<Animator>();
                //plays elevator door anim
                elevatorDoorAnim.Play("door_2_open");
                
                //elevatorDoorAnim.Play("door_2_opened");
            }
            else
            {
                //print("gameObject.tag is" + gameObject.tag);
                //portal1.SetActive(true);
                targetObj.SetActive(true);
                print("portal Set Active");
            }

        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        print("exited collider");

        //room 1 button
        if (other.gameObject.name == pickUpName)
        {
            //print("gameObject.tag is" + gameObject.tag);
            //portal1.SetActive(true);
            targetObj.SetActive(false);
            print("targetObj deactivated");
            ButtonAnimator.Play("ButtonUpAnim");
            ButtonAnimator.Play("ButtonNeutralAnim");
        }

    }

}

