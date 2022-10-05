using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance Instance;
    public string PlayerName;
    public string BestScorePlayer;
    public int BestScorePoints;
    private readonly string saveFilePath = "/bestscore.json";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveBestScore()
    {
        MenuData data = new MenuData(BestScorePlayer, BestScorePoints);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + saveFilePath, json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + saveFilePath;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MenuData data = JsonUtility.FromJson<MenuData>(json);
            BestScorePlayer = data.BestScorePlayer;
            BestScorePoints = data.BestScorePoints;
        }
        else
        {
            BestScorePlayer = "";
            BestScorePoints = 0;
        }
    }
}
