using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileDataHandler
{
    string path = Application.persistentDataPath + "/CoffeeAndDrip/Data";
    string fileName = "/SaveData.txt";

    public FileDataHandler(string dataPath, string dataFileName)
    {
        this.path = dataPath;
        this.fileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(path,fileName);
        GameData loadedData = null;
        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using( FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using ( StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
                
                
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data) 
    {
        string fullPath = Path.Combine(path,fileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonConvert.SerializeObject(data,Formatting.Indented);

            //write to file
            using( FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using ( StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error saving data to disk at: " + path + "\n" + e);
        }
    }
}

