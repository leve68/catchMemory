using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템의 개수
    public Image itemImage; // 아이템의 이미지
    //public bool isAcquired;


    [SerializeField] private Text text_Count;
    private Color grayColor = new Color32(159, 159, 159, 255);
    private Color whiteColor = new Color32(255, 255, 255, 255);

    private void Awake()
    {
        SetColor(item.IsAcquired ? 1 : 0);
        UpdateText();
    }

    // 아이템 이미지의 투명도 조절 - 먹으면 보이게
    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item)
        // 인벤토리에 새로운 아이템 슬롯 추가
    {
        if(item.itemType == _item.itemType)
        {
            itemCount++;
            item.IsAcquired = true;
            SetColor(1);
        }

        if (item.itemSaveType != Item.ItemSaveType.useNow) // 저장 가능 아이템이면
        {
            UpdateText(); // ToString - 재정의
        }
        else
        {
            text_Count.text = "0";
        }

    }

    public void UpdateText()
    {
        text_Count.text = itemCount.ToString();
        if(itemCount > 0)
        {
            itemImage.color = new Color(whiteColor.r, whiteColor.g, whiteColor.b, itemImage.color.a);
            text_Count.color = new Color32(0,0,0,255);
        }
        else
        {
            itemImage.color = new Color(grayColor.r, grayColor.g, grayColor.b, itemImage.color.a);
            text_Count.color = new Color32(0,0,0,0);

        }
    }
    public void SetSlotCount(int _count)
        // 해당 슬롯의 아이템 개수 업데이트
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

    }

}