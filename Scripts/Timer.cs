using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[Serializable]
public class Timer
{

    public List<Record> records = new List<Record>();
    const string folderName = "BinaryTimeRecords";
    const string fileExtension = ".dat";
    string folderPath = Path.Combine(Application.persistentDataPath, folderName);


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //print("Time elapsed: " + Time.timeSinceLevelLoad);
    }
    //string[] GetFilePaths()
    //{
    //    Debug.Log("folderpath: " + folderPath);

    //    return Directory.GetFiles(folderPath, fileExtension);
    //}
    public void load()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string dataPath = Path.Combine(folderPath, "TimeRecords" + fileExtension);
        if (File.Exists(dataPath))
        {
            using (FileStream fileStream = File.Open(dataPath, FileMode.Open))
            {
                records = (List<Record>)binaryFormatter.Deserialize(fileStream);
                Debug.Log("Loaded records count: " + records.Count);
                foreach (Record r in records)
                {
                    Debug.Log("User name: " + r.name);
                    Debug.Log("Time used: " + r.time);
                }
            }
        }
        else
        {
            Debug.Log("File path: " + dataPath + " not exists");

        }

        Debug.Log("Finished Timer.load()");
    }
    public void Save()
    {
        GameControl.control.Load();

        if (GameControl.control.username == null)
        {
            GameControl.control.username = "NONAME";
        }

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string dataPath = Path.Combine(folderPath, "TimeRecords" + fileExtension);
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        if(File.Exists(dataPath))
        {
            load();
        }

        Record newRecord = new Record
        {
            name = GameControl.control.username,
            time = Time.timeSinceLevelLoad
        };
        records.Add(newRecord);
        using (FileStream fileStream = File.Open(dataPath, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, records);
        }

        Debug.Log("records count: " + records.Count);
        foreach (Record r in records)
        {
            Debug.Log("User name: " + r.name);
            Debug.Log("Time used: " + r.time);
        }
        Debug.Log("Finished Timer.Save()");
    }
    public void Print()
    {
        //Debug.Log("name :" + GameControl.control.username);
        //Debug.Log("Time elapsed: " + PlayerPrefs.GetFloat(GameControl.control.username));

        // Print all records in json file
        Debug.Log("Printing all records in binary file");
        List<Record> printRecord = new List<Record>();

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string dataPath = Path.Combine(folderPath, "TimeRecords" + fileExtension);
        using (FileStream fileStream = File.Open(dataPath, FileMode.Open))
        {
            printRecord = (List<Record>)binaryFormatter.Deserialize(fileStream);
        }
        //string[] paths = GetFilePaths();
        //Debug.Log("paths length: " + paths.Length);

        //if (paths.Length > 0)
        //{

        //}
        Debug.Log("printRecord count: " + printRecord.Count);

        foreach (Record record in printRecord)
        {
            Debug.Log("User name: " + record.name);
            Debug.Log("Time used: " + record.time);
        }
        Debug.Log("Finished Timer.Print()");
    }
}

[Serializable]
public class Record
{
    public string name;
    public float time;
}