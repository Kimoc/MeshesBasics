using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using System;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer),typeof (Renderer))]
public class BuildGrid : MonoBehaviour
{
    //Mesh
    private Mesh mesh;
    //Quad variables
    Vector3[] vertices; //Points (vertices)
    int[] triangles; //Triangles
    Vector2[] uvs; //UVs
    //Grid variables
    [Range(1,10)]
    public int xSize = 10; //Size of x axis grid
    [Range(1, 10)]
    public int ySize = 10; //Size of y axis grid
    // Start is called before the first frame update
    void Awake()
    {
        GenerateGrid();
    }
    void Start()
    {
        UpdateMesh();
        
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uvs;
    }

    private void GenerateGrid()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Procedural Grid";
    
        //First we count number of vertexes in the grid
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        //Uvs
        uvs = new Vector2[vertices.Length];
        //Cenereates the vertex points
        for(int y=0,i=0; y<=ySize;y++)
        {
            for (int x = 0; x <= xSize; x++,i++){
                vertices[i] = new Vector3(x, y);
                uvs[i] = new Vector2((float)x/xSize,(float) y/ySize);
            }
        }
        mesh.vertices = vertices;
       
        //Generates the trangles inside the grid
        triangles = new int[xSize*ySize*6];
        for (int triIndex = 0,vertIndex = 0,y=0;y < ySize;y++,vertIndex++){
            for(int x=0; x<xSize;x++, triIndex += 6, vertIndex++)
            {
                triangles[triIndex] = vertIndex;
                triangles[triIndex + 3] = triangles[triIndex + 2] = vertIndex + 1;
                triangles[triIndex + 4] = triangles[triIndex + 1] = vertIndex + xSize + 1;
                triangles[triIndex + 5] = vertIndex + xSize + 2;
                mesh.triangles = triangles;
                
                mesh.uv = uvs;
            }       
        }
        /*one quad testing
        triangles[0] = 0;      
        triangles[3] = triangles[2] = 1; //they share the same vertex
        triangles[4] = triangles[1] = xSize + 1;// they share the same vertex
        triangles[5] = xSize + 2;
        */
        


    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for(int i=0;i<vertices.Length;i++ )
        {
            Gizmos.DrawSphere((transform.TransformPoint(vertices[i])), 0.1f);
        }
    }


}
