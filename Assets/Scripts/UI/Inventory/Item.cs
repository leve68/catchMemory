using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName = "New Item",menuName ="New Item/item")]

public class Item : ScriptableObject // 데이터 컨테이너 에셋 / 스크립트를 에셋으로 생성 가능
{
    public enum ItemSaveType // 아이템 유형 - 저장/즉시사용
    {
        canSave,
        useNow,
    }

    public enum ItemType
    {
        yarn,
        cushion,
        needle,
        ball,
        mirror,
    }

    public ItemType itemType; // 모든 아이템 - 어떤 아이템값인지 인지
    public string itemName; // 아이템 이름
    public ItemSaveType itemSaveType; // 아이템 저장 유형
    public Sprite itemImage; // 아이템의 이미지(인벤토리 안에 띄움)
    public GameObject itemPrefab; // 아이템의 프리팹(아이템 생성 시 프리팹으로 찍어냄)

    public bool IsAcquired
    {
        get
        {
            return PlayerPrefs.GetInt($"{itemType}IsAcquired") > 0;
        }
        set
        {
			PlayerPrefs.SetInt($"{itemType}IsAcquired", value ? 1 : 0);
		}
    }
}
