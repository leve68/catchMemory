using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionController : MonoBehaviour
{
    //������ ȭ�鿡�� ������
    // player�� ��

    [SerializeField]
    private Inventory theInventory;

    [SerializeField]
    private ItemList theitemlist;

    public Item nowitem; // �ε��� ������

    private void Start()
    {
        theInventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        theitemlist = GameObject.Find("ItemList").GetComponent<ItemList>();
        //item.isAcquired = false;
    }


   /* private void OnCollisionEnter2D(Collision2D collision) // collision �ε��� ������Ʈ�� ����
    {
  

        if (collision.gameObject.CompareTag("Item"))
        // �浹�� ������Ʈ�� �±װ� Item�̶��
        {
            nowitem = collision.gameObject.GetComponent<ItemPickUp>().item; // ���� �ε��� ������ �����
            
            // �ش� ������Ʈ �� ��ȯ - Ÿ���� 'cannow..'�� - �����ʿ� �̹��� ����/ cansave�� ���ʿ� �̹��� ���� + ����������
            // �������� �ֿ�� AcquireItem()�� ȣ���Ͽ� �������� �κ��丮 ���Կ� ������Ʈ

            Debug.Log(nowitem.itemName + "ȹ��");
            Destroy(collision.gameObject); // ȭ���� ������ ����
           // item.isAcquired = true; // isAcquired ���¸� ������ ����Ʈ�� ���� ����

            if (!nowitem.isAcquired) // ���� �ʾ������� ItemList�� �ֱ� * �ٽ� �����ϸ� false �ȵ�
            {
                theitemlist.AcquireItemList(nowitem);
                nowitem.isAcquired = true;
            }

            if (nowitem.itemType == Item.ItemType.canSave) // itemtype�� cansave��
            {
                theInventory.AcquireItem(nowitem); // �κ��丮�� �ֱ�
            }

            Debug.Log(GetItem(nowitem));
        }
    }

    public int GetItem(Item item)
    {
        return (int)item.allitems; // ������ enum ���������� ��ȯ

    }
   */
}
