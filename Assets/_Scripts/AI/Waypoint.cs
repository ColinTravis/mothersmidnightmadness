using UnityEngine;
 
public class Waypoint : MonoBehaviour {
    private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, 1.5f, 1.5f));
     }
 }