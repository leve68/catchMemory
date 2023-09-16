using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageScene4 : BaseScene
{
    SaveData unlockData;
    SpawnPoint playerSpawnPoint;

    protected override void Init() // ���� ������ �� �⺻������ �����ؾ� �� �ϵ�
    {
        base.Init();

        SceneType = Define.Scenes.Stage4;
        unlockData = GameMNG.Data.GetSaveData();
        foreach (GameData data in unlockData.saveDatas)
        {
            if (!data.unlocked_stages.Contains(4))
            {
                data.unlocked_stages.Add(4);
                GameMNG.Data.SaveJson<SaveData, int, GameData>("Save", unlockData);
            }
        }
        SpawnPlayer();

        GameObject.FindWithTag("Manager").GetComponent<GameMNG>().LoadData();

        GameMNG.Sound.Play("BGM/캐치메모리_st2_01", Define.Sound.Bgm);
    }

    public override void Clear() //���� �����ϸ鼭 �����ؾ� �� �ϵ�
    {
        GameMNG.Sound.Clear();
        GameObject.FindWithTag("Manager").GetComponent<GameMNG>().SaveData();
    }
    public void SpawnPlayer()
    {
        playerSpawnPoint = GameObject.FindWithTag("Respawn").GetComponent<SpawnPoint>();
        if (GameObject.FindWithTag("Player") == null)
        {
            playerSpawnPoint.SpawnObject();
        }
    }
}
