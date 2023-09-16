using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item item; // ȹ���� ������
    public Image itemImage; // �������� �̹���
    public static Item currentItem;

    public bool isAcquired;

	// ItemList ���� itemslots�� ��ũ��Ʈ �� �־���

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
