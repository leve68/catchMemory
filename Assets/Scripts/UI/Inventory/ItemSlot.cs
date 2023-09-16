using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item item; // 획득한 아이템
    public Image itemImage; // 아이템의 이미지
    public static Item currentItem;

    public bool isAcquired;

	// ItemList 에서 itemslots에 스크립트 다 넣어줌

	private void Awake()
	{
		itemImage.sprite = item.itemImage;
        SetColor_list(item.IsAcquired ? 1 : 0);
	}

	public void Acquire()
    {
		item.IsAcquired = true;
		SetColor_list(1);
	}

    public void SetColor_list(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
}
