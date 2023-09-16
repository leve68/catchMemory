using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� �������� ����
    public Image itemImage; // �������� �̹���
    //public bool isAcquired;


    [SerializeField] private Text text_Count;
    private Color grayColor = new Color32(159, 159, 159, 255);
    private Color whiteColor = new Color32(255, 255, 255, 255);

    private void Awake()
    {
        SetColor(item.IsAcquired ? 1 : 0);
        UpdateText();
    }

    // ������ �̹����� ���� ���� - ������ ���̰�
    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item)
        // �κ��丮�� ���ο� ������ ���� �߰�
    {
        if(item.itemType == _item.itemType)
        {
            itemCount++;
            item.IsAcquired = true;
            SetColor(1);
        }

        if (item.itemSaveType != Item.ItemSaveType.useNow) // ���� ���� �������̸�
        {
            UpdateText(); // ToString - ������
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
        // �ش� ������ ������ ���� ������Ʈ
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

    }

}