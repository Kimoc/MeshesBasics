using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
/*todo
 *
 *Comment order off points quad
 *
 */
[RequireComponent(typeof(MeshFilter))]
public class BuildMesh : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices; //Points (vertices)
    int[] triangles; //Triangles
    Vector2[] uvs; //UVs

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
       
    }
    private void CreateShape()
    {
        //POINTS//
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),// Point 0
            new Vector3(0,0,1),// Point 1
            new Vector3(1,0,0),// Point 2
            new Vector3(1,0,1)//  Point 3
        };
        //TRIANGLES// 3 points, clockwise determinates wich side is visible
        triangles = new int[]
        {
            0,1,2,
            1,3,2
        };
        //UVS//
        uvs = new Vector2[]
        {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0)
        };

    }
    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
