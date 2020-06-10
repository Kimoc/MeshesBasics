using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class BuildMesh : MonoBehaviour
{
    UnityEngine.Color gizmoColor = UnityEngine.Color.white;
    float radiusGizColor = 0.1f;
    Mesh mesh;

    Vector3[] vertices; //Points (vertices)
    int[] triangles; //Triangles
    Vector2[] uvs; //UVs

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //First we indicate unity
        CreateShape();
        UpdateMesh();
       
    }

    private void CreateShape()
    {
        //POINTS//
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),// Point 0 bottom left
            new Vector3(0,0,1),// Point 1 upper left
            new Vector3(1,0,0),// Point 2 bottom right
            new Vector3(1,0,1)//  Point 3 upper right
        };
        //TRIANGLES// 3 points, clockwise determinates wich side is visible
        triangles = new int[]
        {
            0,1,2,//First triangle
            1,3,2 //Second triangle
        };
        //UVS//   The base texture coordinates of the Mesh.
        // UV(W) coordinates are a normalized (0 to 1)
        // 2-Dimensional coordinate system, where the origin (0,0) 
        // exists in the bottom left corner of the space.
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
        mesh.Clear();//Clear prevoius mesh data
        //We input the data
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;//aply uvs
        mesh.Optimize();
        mesh.RecalculateNormals();//For lighting effects Unity uses his own set of data called normals
    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = gizmoColor;
        foreach(Vector3 vertex in vertices)
        {
            Gizmos.DrawSphere(transform.TransformPoint(vertex), radiusGizColor);
        }
    }
}
