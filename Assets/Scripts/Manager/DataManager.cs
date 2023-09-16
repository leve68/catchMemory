using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, GameData> DataDict { get; private set; } = new Dictionary<int, GameData>();

    public void Init()
    {
        LoadData();
    }
    void LoadData()
    {
        SaveData loadedSaveData = LoadJson<SaveData, int, GameData>("Save");

        if (loadedSaveData != null)
        {
            DataDict = loadedSaveData.MakeDict();
        }
        else
        {
            CreateNewSaveData();
        }
    }

    void CreateNewSaveData()
    {
        SaveData newSaveData = new SaveData();
        // ���⿡�� ������ �ʱ�ȭ �۾��� �����ϰ� �����͸� �߰��մϴ�.
        newSaveData.saveDatas.Add(new GameData
        {
            dataNum = 0,
            unlocked_stages = new List<int> { 1 }, // ���÷� �ʱ� ������ �߰�
            unlocked_scenes = new List<int> {  }  // ���÷� �ʱ� ������ �߰�
        });

        string jsonData = JsonUtility.ToJson(newSaveData);
        string filePath = Path.Combine(Application.persistentDataPath, "Save.json");
        File.WriteAllText(filePath, jsonData);

        DataDict = newSaveData.MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        string filePath = Path.Combine(Application.persistentDataPath, $"{path}.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<Loader>(jsonData);
        }
        else
        {
            Debug.LogWarning($"File not found: {filePath}");
            return default(Loader);
        }
    }

    public void SaveJson<Loader, Key, Value>(string path, Loader data) where Loader : ILoader<Key, Value>
    {
        string jsonData = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.persistentDataPath, $"{path}.json");
        File.WriteAllText(filePath, jsonData);

        UpdateDataFromJson();
    }
    public void UpdateDataFromJson()
    {
        SaveData loadedSaveData = LoadJson<SaveData, int, GameData>("Save");

        if (loadedSaveData != null)
        {
            DataDict = loadedSaveData.MakeDict();
        }
        else
        {
            Debug.LogWarning("Failed to load save data.");
        }
    }
    public SaveData GetSaveData()
    {
        return LoadJson<SaveData, int, GameData>("Save");
    }
}

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

