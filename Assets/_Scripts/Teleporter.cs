using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // public GameObject Portal;
    // public GameObject Player;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         StartCoroutine (Teleport());
    //     }
    // }

    // IEnumerator Teleport()
    // {
    //     yield return new WaitForSeconds (5f);
    //     Player.transform.position = new Vector2 (Portal.transform.position.x, Portal.transform.position.y);
    // }

     public GameObject teleport;
    public GameObject player;

    public bool canTeleport;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && canTeleport)
        {
            StartCoroutine(Teleport());
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            canTeleport = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            canTeleport = false;
        }
    }

    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.2f);
        player.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);
        StopCoroutine(Teleport());
    }
}
