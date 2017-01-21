using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInfo {
    public static float maxLuminocity = 25.4f;
    public int hygID;
    public float magnitude;
    public Vector3 position;
    public string color;
    public float luminosity;

    public StarInfo(int hygID, float magnitude, Vector3 position, string color, float luminosity)
    {
        this.hygID = hygID;
        this.magnitude = magnitude;
        this.luminosity = luminosity;
        this.position = position;
        this.color = color;
    }

    public override string ToString()
    {
        string str = "";
        str += "HYG ID: " + hygID + ", Position: " + position.ToString() + ", magnitude: " + magnitude;
        str += ", Color index: " + color + ", Luminosity: " + luminosity;
        return str;
    }
}
