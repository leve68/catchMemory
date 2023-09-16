using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LIfe : MonoBehaviour
{
    [SerializeField] int life = 3;
    private int leftLife;
    void Start()
    {
        lifeStart();
    }
    void lifeStart() // ������ �ʱ�ȭ
    {
        leftLife = life;
    }
    public void LifeOut()
    {
        if (leftLife > 0)
        {
            leftLife--;
        }
    }
    public void LifeIn()
    {
        if (leftLife < life)
        {
            leftLife++;
        }
    }
    public int GetLife() //���� ü�� ��ȯ
    {
        return leftLife;
    }
}
