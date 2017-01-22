using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInfo {
    public static float maxLuminocity = 25.4f;
    public int hygID;
    public float magnitude;
    public Vector3 position;
    public float luminosity;
    public int red = 0;
    public int blue = 0;
    public int green = 0;
    public string name;

    public StarInfo(int hygID, float magnitude, Vector3 position, char spectrum, float luminosity, string name)
    {
        this.hygID = hygID;
        this.name = name;
        this.magnitude = magnitude;
        this.luminosity = luminosity;
        this.position = position;
        switch (spectrum) {
            case 'O': this.red = 0;
                       this.blue = 127;
                        this.green = 255;
                        break;
            case 'B':  this.red = 0;
                       this.blue = 255;
                        this.green = 255;
                        break;
            case 'A':  this.red = 185;
                       this.blue = 255;
                        this.green = 255;
                        break;
            case 'F':  this.red = 255;
                       this.blue = 255;
                        this.green = 255;
                        break;
            case 'G':  this.red = 255;
                       this.blue = 255;
                        this.green = 0;
                        break;
            case 'K':  this.red = 255;
                        this.blue = 127;
                        this.green = 0;
                        break;
            case 'M':  this.red = 255;
                       this.blue = 0;
                        this.green = 0;
                        break;
            default:  this.red = 255;
                       this.blue = 255;
                        this.green = 255;
                        break;
        }
}
    public override string ToString()
    {
        string str = "";
        str += "HYG ID: " + hygID + ", Position: " + position.ToString() + ", magnitude: " + magnitude;
        str += ", Luminosity: " + luminosity;
        return str;
    }
    public bool hasName()
    {
        if (this.name != "") return true;
        else return false;
    }
}
