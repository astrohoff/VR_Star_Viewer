using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {
    private Mesh starMesh;

	// Use this for initialization
	void Awake () {
        // Add "Mesh" components to object.
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRend = gameObject.AddComponent<MeshRenderer>();
        // Create empty mesh.
        starMesh = new Mesh();
        meshFilter.mesh = starMesh;
        // Add white material.
        Material mat = new Material(Shader.Find("Unlit/Color"));
        mat.color = Color.white;
        meshRend.material = mat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateStars(Vector3[] positions, Color[] colors, float distance)
    {
        Debug.Log("Generating stars");
        // Set stars to given distance.
        int[] indices = new int[positions.Length];
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = positions[i].normalized * distance;
            indices[i] = i;
        }
        // Set mesh attributes.
        starMesh.vertices = positions;
        starMesh.colors = colors;
        starMesh.SetIndices(indices, MeshTopology.Points, 0);
        // Update the mesh rendering bounds.
        starMesh.RecalculateBounds();
    }

}
