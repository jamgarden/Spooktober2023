using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // When the game starts, we should load the game
    }

    // Update is called once per frame
    public SaveData saveRetrieval()
    {

        string test = File.ReadAllText("./saveGame.json");
        Debug.Log(test);

        // SaveData sData = JsonSerializer.Deserialize<SaveData>(test);
        return null; // needs to return a thing!

    }

    public void SaveGame(SaveData dataIn)
    {
        //XmlSerializer xSerializer = new XmlSerializer(dataIn.GetType());
        //xSerializer.Serialize(Debug.Out, dataIn);
    }
}
