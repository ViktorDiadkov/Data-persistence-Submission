using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance;
    public string userName;
    private static int recordScore;
    private static string bestUser;
    
    public static GameData Instance { get { return instance; } }
    public static int RecordScore { get { return recordScore; } }
    public static string BestUser { get { return bestUser; } }
    private void Awake()
    {
        
        if (instance == null)
        {
        instance = this;
        instance.userName = "Name";
        DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
        
    }

    [Serializable]
    public class SaveData
    {
        public int record;
        public string userName;
    }
    public static void Save()
    {
        SaveData data = new SaveData() { record = recordScore, userName = bestUser }; 
        string json = JsonUtility.ToJson(data);
        File.WriteAllText( Application.persistentDataPath + "/savefile.json", json);
    }

    public static void Load() 
        {
        string datapath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(datapath))
        {
            string json = File.ReadAllText(datapath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestUser = data.userName;
            recordScore = data.record;
        }

        }

    public void UpdateRecord(int record)
    {
        recordScore = record;
        bestUser = userName;
    }

    public void setUserName (string userName)
    {
        instance.userName = userName;
    }
    
}
