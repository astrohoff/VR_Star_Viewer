using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class HYGParser : MonoBehaviour{
    public TextAsset database;
    public int readLimit = 5;
    public StarGenerator starGenerator;

    private void Start()
    {
        StringReader strReader = new StringReader(database.text);
        List<StarInfo> starInfos = new List<StarInfo>();
        // Skip field names.
        string line = strReader.ReadLine();
        string[] fieldNames = line.Split(new char[] { ',' });
        string fieldIndices = "";
        for(int i = 0; i < fieldNames.Length; i++)
        {
            fieldIndices += i + ": " + fieldNames[i] + ", "; 
        }
        Debug.Log(fieldIndices);
        int readCount = 0;
        bool reachedEnd = false;
        while(readCount < readLimit && !reachedEnd)
        {
            line = strReader.ReadLine();
            if(line == null)
            {
                reachedEnd = true;
            }
            else
            {
                string[] fields = line.Split(new char[] { ',' });
                string name = fields[7];
                int id = Convert.ToInt32(fields[0]);
                float magnitude = Convert.ToSingle(fields[13]);
                string colorIndex = fields[15];
                char spectrum = colorIndex[0];
                float x = Convert.ToSingle(fields[17]);
                float y = Convert.ToSingle(fields[18]);
                float z = Convert.ToSingle(fields[19]);
                float luminosity = Convert.ToSingle(fields[33]);
                Vector3 position = new Vector3(x, y, z);
                StarInfo sInfo = new StarInfo(id, magnitude, position, spectrum, luminosity, name);
                starInfos.Add(sInfo);
                //Debug.Log(sInfo.ToString());
                readCount++;
            }
        }
        starGenerator.GenerateStars(starInfos.ToArray(), 100);
    }
}
