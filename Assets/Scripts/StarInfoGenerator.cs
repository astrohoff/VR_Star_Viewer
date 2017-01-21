using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInfoGenerator : MonoBehaviour {
    public int starCount = 1000;
    public float distance = 100;

	// Use this for initialization
	void Start () {
        Debug.Log("Generating star info");
        Vector3[] positions = new Vector3[starCount];
        Color[] colors = new Color[starCount];
        for(int i = 0; i < starCount; i++)
        {
            positions[i] = Random.onUnitSphere * distance;
            colors[i] = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
        //GetComponent<StarGenerator>().GenerateStars(positions, colors, distance);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
