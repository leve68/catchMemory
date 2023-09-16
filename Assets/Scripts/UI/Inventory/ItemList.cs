using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemList : MonoBehaviour //이미지만 저장하는 함수
{
    public ItemSlot[] itemslots;
    Inventory inventory;
    Image quickslotImage;

    [SerializeField]
    private GameObject go_ItemListBase; // Inventory_Base 이미지

    public static Item currentItem;



    private void Start()
    {
        itemslots = go_ItemListBase.GetComponentsInChildren<ItemSlot>();
    }

    public void AcquireItemList(Item _item) // itemlist의 AcquireItem
    // 인벤토리에 새로운 아이템 슬롯 추가
    {
        currentItem = _item;

        for (int i = 0; i < itemslots.Length; i++) // 아이템이 없는 경우 - 빈 슬롯 찾음
        {
            if (itemslots[i].item.itemType == _item.itemType)
            {
                itemslots[i].Acquire();

            }
        }
    }


}
