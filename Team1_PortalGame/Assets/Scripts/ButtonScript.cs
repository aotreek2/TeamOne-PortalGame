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
    private GameObject portal1, door1, RedPortal1, RedDoor;
    //portal2, portal3, elevator, door1, door2, door3; 


    private void Start()
    {
        //Level 1
        portal1 = GameObject.Find("Portal1");
        door1 = GameObject.Find("Door1");
        RedPortal1 = GameObject.Find("RedPortalPair1");
        RedDoor = GameObject.Find("Door1");

        /*
                portal2 = GameObject.Find("Portal2");
                portal3 = GameObject.Find("Portal3");
                elevator = GameObject.Find("Elevator");
                door2 = GameObject.Find("Door2");
                door3 = GameObject.Find("Door3");
                */

        RedPortal1.SetActive(false);
        RedDoor.SetActive(true);
    }

    //each button is set to trigger a specific action when a pickup is placed on them based on name of button and name of button.
    private void OnTriggerEnter(Collider other)
    {
        print("entered collider");

        //room 1 button
        //if(gameObject.tag == "Button1" && other.gameObject.tag == "PickUp1")
        if (gameObject.tag == "Button1" && other.gameObject.tag == "Player")
        {
            //print("gameObject.tag is" + gameObject.tag);
            //portal1.SetActive(true);
            RedPortal1.SetActive(true);
            print("portal Set Active");
        }
        {

            //room 1 button
            if(gameObject.tag == "Button2" && other.gameObject.tag == "PickUp1")
            if (gameObject.tag == "Button2" && other.gameObject.tag == "Player")
            {
                print("gameObject.tag is" + gameObject.tag);
                portal1.SetActive(true);
                RedDoor.SetActive(false);
            }
        }



    }
}
