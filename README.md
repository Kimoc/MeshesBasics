# UNITY MESH BASICS

![GitHub last commit](https://img.shields.io/github/last-commit/Kimoc/MeshesBasics?style=plastic)
![GitHub issues](https://img.shields.io/github/issues/Kimoc/MeshesBasics?style=plastic)
![GitHub All Releases](https://img.shields.io/github/downloads/Kimoc/MeshesBasics/total?style=plastic)
![GitHub contributors](https://img.shields.io/github/contributors/Kimoc/MeshesBasics?style=plastic)

### Vertices

In Unity any mesh is made of points called vertizes representing a position in the world.

------------------------------------------------------------------------------------------------------

<a href="https://imgbb.com/"><img src="https://i.ibb.co/vQPQNqH/vertizes-1.png" alt="vertizes-1"
width="40%" height="40%"></a>

------------------------------------------------------------------------------------------------------

## Quad

A quad is made of 4 vertices. It is represented by an vertex array

<a href="https://imgbb.com/"><img src="https://i.ibb.co/vYp2cZ8/quad.png" alt="quad"
width="30%" height="30%" ></a>

Having the points isn't enough in Unity. We need to fill them out with tirangles. In the case of a quad we will need two. To create the tirangle we need 3 points(vertex), and its very important in wich order we draw them. In this case, we use a clockwise (purple) order to draw both the triangles of the quad.
Points
| Point         | Vertice       |
|:-------------:|:-------------:|
| 0             |     0,0       |
| 1             |     0,1       |
| 2             |     1,0       |
| 3             |     1,1       |
The first triangle in order of point(vertex)= 0,1,2 (yellow)*
The second triangle is a little more tricky = 1,3,2 (green)*

Ass long as we use a clockwise order it does not matter the inital point of the triangle, we do that to prevent backface culling.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/qJqwhSS/triangles-quad.png" alt="triangles-quad" width="50%" height="60%"></a>

------------------------------------------------------------------------------------------------------

## Creating a Mesh

Create a empty object and first add a "Mesh Filter" component and then a "Mesh Renderer Component"

<a href="https://imgbb.com/"><img src="https://i.ibb.co/tZT7zjJ/unity-mesh-filter-1.png" alt="vertizes-1" width="40%" height="40%"></a>
