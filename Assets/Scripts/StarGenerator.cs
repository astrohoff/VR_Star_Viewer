using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {
    public Material starMaterial;
    public float minMagnitude = 6;
    public float maxMagnitude = 0;
    private static int MaxVertices = 65000;
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateStars(StarInfo[] starInfos, float distance)
    {
        float maxBrightness = Mathf.Pow(2.512f, minMagnitude - maxMagnitude);
        //Debug.Log("Max brightness: " + maxBrightness);
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
            int meshIndex = 0;
            while (meshIndex < MaxVertices && starIndex < starInfos.Length)
            {
                if(starInfos[starIndex].magnitude < minMagnitude)
                {
                    //Debug.Log("Star info: " + starInfos[starIndex].ToString());
                    vertices.Add(starInfos[starIndex].position.normalized * distance);
                    float brightness = Mathf.Pow(2.512f, minMagnitude - starInfos[starIndex].magnitude);
                    //Debug.Log("brightness: " + brightness);
                    float rgbVal = brightness / maxBrightness;
                    colors.Add(Color.white * rgbVal);
                    //Debug.Log((Color.white * rgbVal).ToString());
                    indices.Add(meshIndex);
                    meshIndex++;
                }
                
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
