using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject player;
    
    public float runSpeed = 40f;

    // bool jump = false;
    public bool crouch = false;

    float horizontalMove = 0f;
    public float hideOffset = 1f;

    // Update is called once per frame
    void Update()
    {
       horizontalMove =  Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //         jump = true;
    //    }

       if (Input.GetButtonDown("Crouch"))
       {
           crouch = true;
           animator.Play("Player_Hide");
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + hideOffset);
           

       } else if  (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
           animator.Play("Player_UnHide");
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - hideOffset);
       }
    }

    // public void OnHiding (bool IsHiding)
    // {
    //     animator.SetBool("isHiding", IsHiding);
    // }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, false);
        // jump = false;
    }
}
