using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {
    private Mesh starMesh;
    public Material starMaterial;
	// Use this for initialization
	void Awake () {
        // Add "Mesh" components to object.
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRend = gameObject.AddComponent<MeshRenderer>();
        // Create empty mesh.
        starMesh = new Mesh();
        meshFilter.mesh = starMesh;
        meshRend.material = starMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateStars(StarInfo[] starInfos, float distance)
    {
        
        Vector3[] positions = new Vector3[starInfos.Length];
        int[] indices = new int[starInfos.Length];
        // Make all stars white for now.
        Color[] colors = new Color[starInfos.Length];
        for(int i = 0; i < starInfos.Length; i++)
        {
            indices[i] = starInfos[i].hygID;
            positions[i] = starInfos[i].position.normalized * distance;
            colors[i] = Color.white;
        }
        // Set mesh attributes.
        starMesh.vertices = positions;
        starMesh.colors = colors;
        starMesh.SetIndices(indices, MeshTopology.Points, 0);
        // Update the mesh rendering bounds.
        starMesh.RecalculateBounds();
    }

}
