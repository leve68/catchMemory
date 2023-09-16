using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCutScene : MonoBehaviour
{

    [SerializeField] List<GameObject> Pages = new List<GameObject>();

    void PlayNextPage()
    {
        Pages[0].SetActive(false); // ���� �ƽ�(Page1) ���ֱ�
        Pages[1].SetActive(true);
    }  
}
