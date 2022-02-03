using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public int bestScore;
    public string bestScorePlayer;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            bestScore = 0;
            DontDestroyOnLoad(gameObject);
            LoadSaveData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
        public string bestScorePlayer;
    }

    public string GetBestScore()
    {
        return $"Best Score : {bestScorePlayer} : {bestScore}";
    }

    public void SetSaveData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScore = bestScore;
        data.bestScorePlayer = bestScorePlayer;
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadSaveData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScore = data.bestScore;
            bestScorePlayer = data.bestScorePlayer;
        }
    }
}
