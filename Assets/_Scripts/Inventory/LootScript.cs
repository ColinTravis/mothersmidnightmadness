using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{

    public GameObject chest;
    public bool playerInRange;
    [SerializeField] GameObject[] items;

void Start()
{

}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            Debug.Log("Player left range");
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && playerInRange)
        {
            Debug.Log("Opened");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player in Range");
            if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button16))
            {
                // if (!doorIsOpen)
                // {
                //     print("Open the door");
                //     doorToOpen.GetComponent<Animation>().Play("doorOpen");
                //     doorIsOpen = true;
                // }
            }
        }
    }

}
