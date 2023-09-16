using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Data
[Serializable]
public class GameData
{
    public int dataNum;
    public List<int> unlocked_stages;
    public List<int> unlocked_scenes;
}

[Serializable]
public class SaveData : ILoader<int, GameData>
{
    public List<GameData> saveDatas = new List<GameData>();  // json 파일에서 여기로 담김

    public Dictionary<int, GameData> MakeDict() // 오버라이딩
    {
        Dictionary<int, GameData> dataDict = new Dictionary<int, GameData>();
        foreach (GameData data in saveDatas) // 리스트에서 Dictionary로 옮기는 작업
            dataDict.Add(data.dataNum, data); // level을 ID(Key)로 
        return dataDict;
    }
}
#endregion

