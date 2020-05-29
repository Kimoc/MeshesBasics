# UNITY MESH BASICS

![GitHub last commit](https://img.shields.io/github/last-commit/Kimoc/MeshesBasics?style=plastic)
![GitHub issues](https://img.shields.io/github/issues/Kimoc/MeshesBasics?style=plastic)
![GitHub All Releases](https://img.shields.io/github/downloads/Kimoc/MeshesBasics/total?style=plastic)
![GitHub contributors](https://img.shields.io/github/contributors/Kimoc/MeshesBasics?style=plastic)

Basics in how to create our own meshes in unity and understand how they work.

## Vertices

In Unity any mesh is made of points called vertizes representing a position in the world.

------------------------------------------------------------------------------------------------------

<a href="https://imgbb.com/"><img src="https://i.ibb.co/vQPQNqH/vertizes-1.png" alt="vertizes-1"
width="40%" height="40%"></a>

------------------------------------------------------------------------------------------------------

## Quad

A quad is made of 4 vertices. It is represented by an vertex array

<a href="https://imgbb.com/"><img src="https://i.ibb.co/vYp2cZ8/quad.png" alt="quad"
width="30%" height="30%" ></a>

Points
| Point         | Vertice       |
|:-------------:|:-------------:|
| 0             |     0,0       |
| 1             |     0,1       |
| 2             |     1,0       |
| 3             |     1,1       |

Having the points isn't enough in Unity. We need to fill them out with tirangles. In the case of a quad we will need two. To create the tirangle we need 3 points(vertex), and its very important in wich order we draw them. In this case, we use a clockwise (purple) order to draw both the triangles of the quad.

The first triangle in order of point(vertex)= 0,1,2 (yellow)*
The second triangle is a little more tricky = 1,3,2 (green)*

Ass long as we use a clockwise order it does not matter the inital point of the triangle, we do that to prevent backface culling.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/qJqwhSS/triangles-quad.png" alt="triangles-quad" width="50%" height="60%"></a>

------------------------------------------------------------------------------------------------------

## Creating a Quad

Create a empty object and first add a "Mesh Filter" component and then a "Mesh Renderer Component"

<a href="https://imgbb.com/"><img src="https://i.ibb.co/tZT7zjJ/unity-mesh-filter-1.png" alt="vertizes-1" width="40%" height="40%"></a>

Add a new material to the object.

### Code
Using the described coordenates system shown previously, we can implement them in a script (BuildMech) to create the triangles of our quad.
We start creating the script and adding it to our empty object.
On out start method we create a mesh. And them we add two new functions: CreateShape() and UpdateMesh().

```csharp
 void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }
```

### CreateShape()

First we create a vertex array(Vector3 in unity) and define our points.

```csharp
//POINTS
vertices = new Vector3[]
        {
            new Vector3(0,0,0),// Point 0 bottom left
            new Vector3(0,0,1),// Point 1 upper left
            new Vector3(1,0,0),// Point 2 bottom right
            new Vector3(1,0,1)//  Point 3 upper right
        };
```

Once we have the points we can asign them to create triangles with and triangle array

```csharp
//TRIANGLES// 3 points, clockwise determinates wich side is visible

triangles = new int[]
        {
            0,1,2,//First triangle
            1,3,2 //Second triangle
        };
```

If we wanted to apply some texture to your mesh, we can do so by createn uv array.

```csharp
//UVS//   The base texture coordinates of the Mesh.
    // UV(W) coordinates are a normalized (0 to 1)
    // 2-Dimensional coordinate system, where the origin (0,0)
    // exists in the bottom left corner of the space.
    uvs = new Vector2[]
    {
        new Vector2(0,1),// Point 0 bottom left
        new Vector2(0,0),// Point 1 upper left
        new Vector2(1,1),// Point 2 bottom right
        new Vector2(1,0)//  Point 3 upper right
    };
```

### UpdateShape()

After creating the mesh we update clear it from prevoius data and update it with our input data (Vertices and tirangles).

```csharp
private void UpdateMesh()
    {
        mesh.Clear();// clear prevoius data
        //we input or vertex and tirangles
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        //For lighting effects Unity uses his own set of data called normals
        mesh.RecalculateNormals();
    }
```

### QUAD RESULT
You can see the the code [here](https://github.com/Kimoc/MeshesBasics/blob/master/Meshes%20Basics/Assets/Scripts/BuildMesh.cs).

<a href="https://ibb.co/4tv3VYC"><img src="https://i.ibb.co/vqyRjQf/wuad-result.png" alt="wuad-result" width="40%" height="40%"></a>