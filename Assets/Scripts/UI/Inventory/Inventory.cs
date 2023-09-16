using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base �̹���

    Item item;
    Slot slot;
    

    private  Slot[] slots = new Slot[3];
    [SerializeField]
    private List<GameObject> quickslots = new List<GameObject>();

    private void Start()
    {
        slots = go_InventoryBase.GetComponentsInChildren<Slot>();
    }


    public void AcquireItem(Item _item) // ������ �����ϱ�
    {
        if(Item.ItemSaveType.useNow != _item.itemSaveType) // canSave�� ��� ������ ���� ���ϱ� // �� ������Ʈ ��ȣ��� ���ֱ�
        {
            if (Item.ItemType.yarn == _item.itemType)
            {
                slots[0].AddItem(_item);
            }
            if (Item.ItemType.ball == _item.itemType)
            {
                slots[1].AddItem(_item);
            }
            if (Item.ItemType.mirror == _item.itemType)
            {
                slots[2].AddItem(_item);
            }
        }
        else
        {

        }
    }
    //�ش� ���� �ϳ� ����
    public void ClearSlot()
    {
        for (int i = 0; i < 3; i++)
        {
            slots[i].item = null;
            slots[i].itemCount = 0;
        }
    }
}
