using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{

    public static GameControl control;

    public string username;
    public bool bgm;

    // Start is called before the first frame update
    void Awake(){
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/AREscapeInfo.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        PlayerData data = new PlayerData();
        data.username = username;
        data.bgm = bgm;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/AREscapeInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/AREscapeInfo.dat");
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            username = data.username;
            bgm = data.bgm;
        }
    }
}

[Serializable]
class PlayerData
{
    public String username;
    public bool bgm;
}