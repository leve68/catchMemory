
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageScene1 : BaseScene
{
    SaveData unlockData;
    SpawnPoint playerSpawnPoint;

    protected override void Init() // ���� ������ �� �⺻������ �����ؾ� �� �ϵ�
    {
        base.Init();
        SceneType = Define.Scenes.Stage1;
        
        unlockData = GameMNG.Data.GetSaveData();
        foreach (GameData data in unlockData.saveDatas) // GameData의 데이터 교체
        {
            if (!data.unlocked_stages.Contains(1)) //1을 가지고 있지 않다면 배열 교체
            {
                data.unlocked_stages.Add(1);
                GameMNG.Data.SaveJson<SaveData, int, GameData>("Save", unlockData); //json에 저장
            }
        }

        GameMNG.Sound.Play("BGM/캐치메모리_st1", Define.Sound.Bgm);

        SpawnPlayer();

        GameObject.FindWithTag("Manager").GetComponent<GameMNG>().LoadData();

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
