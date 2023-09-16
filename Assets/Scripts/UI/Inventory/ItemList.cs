using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemList : MonoBehaviour //�̹����� �����ϴ� �Լ�
{
    public ItemSlot[] itemslots;
    Inventory inventory;
    Image quickslotImage;

    [SerializeField]
    private GameObject go_ItemListBase; // Inventory_Base �̹���

    public static Item currentItem;



    private void Start()
    {
        itemslots = go_ItemListBase.GetComponentsInChildren<ItemSlot>();
    }

    public void AcquireItemList(Item _item) // itemlist�� AcquireItem
    // �κ��丮�� ���ο� ������ ���� �߰�
    {
        currentItem = _item;

        for (int i = 0; i < itemslots.Length; i++) // �������� ���� ��� - �� ���� ã��
        {
            if (itemslots[i].item.itemType == _item.itemType)
            {
                itemslots[i].Acquire();

            }
        }
    }


}
