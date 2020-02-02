using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTrigger : MonoBehaviour
{
    public MomEnemy momAi;
void Start()
{
        GameObject g = GameObject.FindGameObjectWithTag("Mom");

        momAi = g.GetComponent<MomEnemy>();
}

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            momAi.inViewCone = true;
            print("Mom can see you");
        }
    }
    void OnTriggerExit2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            momAi.inViewCone = false;
            print("Mom can't see you");
        }
    }
}