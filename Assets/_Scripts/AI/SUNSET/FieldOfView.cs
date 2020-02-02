using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        // Vertex 0 is origin
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance);
            if(raycastHit2D.collider == null){
                // No hit
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            } else {
                // Hit object
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            // Actually decreasing due to direction clockwise vs. counter
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
