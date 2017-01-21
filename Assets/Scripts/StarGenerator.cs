using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {
    public Material starMaterial;
    private static int MaxVertices = 65000;
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateStars(StarInfo[] starInfos, float distance)
    {
        int starIndex = 0;
        int meshNum = 0;
        while (starIndex < starInfos.Length)
        {
            GameObject starsSegment = new GameObject("Star Mesh " + meshNum);
            starsSegment.transform.position = transform.position;
            starsSegment.transform.SetParent(transform, true);
            Mesh mesh = new Mesh();
            List<Vector3> vertices = new List<Vector3>();
            List<Color> colors = new List<Color>();
            List<int> indices = new List<int>();
            for (int meshIndex = 0; meshIndex < MaxVertices && starIndex < starInfos.Length; meshIndex++)
            {
                vertices.Add(starInfos[starIndex].position.normalized * distance);
                colors.Add(Color.white);
                indices.Add(meshIndex);
                starIndex++;
            }
            mesh.SetVertices(vertices);
            mesh.SetColors(colors);
            mesh.SetIndices(indices.ToArray(), MeshTopology.Points, 0);
            MeshFilter meshFilter = starsSegment.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;
            MeshRenderer meshRend = starsSegment.AddComponent<MeshRenderer>();
            meshRend.material = starMaterial;
            meshNum++;
        }
    }

}
