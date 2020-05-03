using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCreator : MonoBehaviour
{
    [SerializeField] private Material material;
    private void Start()
    {
        var mesh = new Mesh();
        var meshFilter = GetComponent<MeshFilter>();
        var meshRenderer = GetComponent<MeshRenderer>();

        // Create a Quad (Square) with 4 points, pass them in "Z" Shape
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0f, 1f),    // 0 - Top Left
            new Vector3(1f, 1f),    // 1 - Top Right
            new Vector3(0f, 0f),    // 2 - Bot Left
            new Vector3(1f, 0f)     // 3 - Bot Right
        };
        
        // Quads are displayed with the help of 2 triangles
        // Each array element is 1 point of a triangle
        // 0 to 2 - triangle one, 3 to 5 - triangle two
        // It's important to put them in clockwise order (refer to square vertices)
        int[] triangles = new int[6]
        {
            // Polygon 1: upper left triangle
            0, 1, 2,
            // Polygon 2: lower right triangle
            3, 2, 1
        };

        // To display Textures on the Mesh’s Material correctly, add texture coordinates to the Mesh.
        // Each vertex in the Mesh has a texture coordinate which specifies where on the Material’s Texture to sample from. 
        // Texture coordinates are between 0 and 1, (0,0) is the bot left corner, (1,1) is the top right corner of a texture.
        Vector2[] uv = new Vector2[4]
        {
            
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(0f, 0f),           
            new Vector2(1f, 0f)
        };
        

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        meshFilter.mesh = mesh;
        meshRenderer.material = material;
        // Hidden settings which allow you to display a mesh on a scene in desired order, just as if it was a Sprite
        meshRenderer.sortingLayerName = "UI";
        meshRenderer.sortingOrder = 100;
    }
}
