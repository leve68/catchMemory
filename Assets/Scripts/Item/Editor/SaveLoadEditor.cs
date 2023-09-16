using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveLoadEditor : Editor
{
    [MenuItem("Window/저장 데이터 날리기")]
    public static void DeleteSavedata()
    {
        PlayerPrefs.DeleteAll();
    }
}

