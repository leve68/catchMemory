using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveLoadEditor : Editor
{
    [MenuItem("Window/���� ������ ������")]
    public static void DeleteSavedata()
    {
        PlayerPrefs.DeleteAll();
    }
}

