using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController control;
    public string email;
    public string password;
    public string displayName;
    public string bestScore;
    private void Awake()
    {
        if ( control == null )
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control!=this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();
    }
    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");
        PlayerData data = new PlayerData();
        data.email = email;
        data.password = password;
        data.displayName = displayName;
        data.bestScore = bestScore;
        bf.Serialize(file , data);
        file.Close();
    }
    public void Load()
    {
        if ( File.Exists(Application.persistentDataPath + "/PlayerInfo.banana")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat",FileMode.Open);
            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();
            email = data.email;
            password = data.password;
            displayName = data.displayName;
            data.bestScore = bestScore;
        }
    }
}
[Serializable]
class PlayerData {
  public string email;
  public string password;
  public string displayName;
  public string bestScore;
}
