using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionController : MonoBehaviour
{
    //닿으면 화면에서 없어짐
    // player에 들어감

    [SerializeField]
    private Inventory theInventory;

    [SerializeField]
    private ItemList theitemlist;

    public Item nowitem; // 부딪힌 아이템

    private void Start()
    {
        theInventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        theitemlist = GameObject.Find("ItemList").GetComponent<ItemList>();
        //item.isAcquired = false;
    }


   /* private void OnCollisionEnter2D(Collision2D collision) // collision 부딪힌 오브젝트의 정보
    {
  

        if (collision.gameObject.CompareTag("Item"))
        // 충돌한 오브젝트의 태그가 Item이라면
        {
            nowitem = collision.gameObject.GetComponent<ItemPickUp>().item; // 현재 부딪힌 아이템 갖고옴
            
            // 해당 오브젝트 값 반환 - 타입이 'cannow..'면 - 오른쪽에 이미지 생성/ cansave면 양쪽에 이미지 생성 + 데이터저장
            // 아이템을 주우면 AcquireItem()을 호출하여 아이템을 인벤토리 슬롯에 업데이트

            Debug.Log(nowitem.itemName + "획득");
            Destroy(collision.gameObject); // 화면의 아이템 삭제
           // item.isAcquired = true; // isAcquired 상태면 아이템 리스트에 들어가지 않음

            if (!nowitem.isAcquired) // 얻지 않았을때만 ItemList에 넣기 * 다시 실행하면 false 안됨
            {
                theitemlist.AcquireItemList(nowitem);
                nowitem.isAcquired = true;
            }

            if (nowitem.itemType == Item.ItemType.canSave) // itemtype이 cansave면
            {
                theInventory.AcquireItem(nowitem); // 인벤토리에 넣기
            }

            Debug.Log(GetItem(nowitem));
        }
    }

    public int GetItem(Item item)
    {
        return (int)item.allitems; // 아이템 enum 정수값으로 반환

    }
   */
}
