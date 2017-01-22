using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInfo {
    public static float maxLuminocity = 25.4f;
    public string name;
    public int hygID;
    public float magnitude;
    public Vector3 position;
    public Color32 color;
    public float luminosity;

    public StarInfo(int hygID, float magnitude, Vector3 position, char spectrum, float luminosity, string name)
    {
        this.hygID = hygID;
        this.magnitude = magnitude;
        this.luminosity = luminosity;
        this.position = position;
        this.name = name;
        switch(spectrum)
        {
            case 'O' :
                // indigo
                this.color = new Color32( 0, 127, 255, 255);
                break;
            case 'B' :
                // gator blue
                this.color = new Color32(0, 255, 255, 255);
                break;
            case 'A':
                // cyan
                this.color = new Color32(185, 255, 255, 255);
                break;
            case 'F':
                // white
                this.color = new Color32(255, 255, 255, 255);
                break;
            case 'G':
                // yellow
                this.color = new Color32(255, 255, 0, 255);
                break;
            case 'K':
                // orange
                this.color = new Color32(255, 127, 0, 255);
                break;
            case 'M':
                // red
                this.color = new Color32(255, 0, 0, 255);
                break;
            default:
                //white
                this.color = new Color32(255, 255, 255, 255);
                break;
        }
    }

    public override string ToString()
    {
        string str = "";
        str += "HYG ID: " + hygID + ", Position: " + position.ToString() + ", Relative magnitude: " + magnitude;
        str += ", Luminosity: " + luminosity;
        return str;
    }

    public bool hasName()
    {
        if (this.name != "") return true;
        else return false;
    }
}
