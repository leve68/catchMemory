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
    public List<GameData> saveDatas = new List<GameData>();  // json ���Ͽ��� ����� ���

    public Dictionary<int, GameData> MakeDict() // �������̵�
    {
        Dictionary<int, GameData> dataDict = new Dictionary<int, GameData>();
        foreach (GameData data in saveDatas) // ����Ʈ���� Dictionary�� �ű�� �۾�
            dataDict.Add(data.dataNum, data); // level�� ID(Key)�� 
        return dataDict;
    }
}
#endregion

