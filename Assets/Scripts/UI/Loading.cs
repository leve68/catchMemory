using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Loading : UI_Scene
{
    public static Image loadBar;
    enum Images
    {
        loadingBar,
    }
    private void Start()
    {
        //Init()  �� Init�Լ��� loadingScene���� ȣ������ (����: LoadingScene ��Ÿ�Ӻ��� ������ UI�ϼ� �ʿ�)
    }
    public override void Init()
    {
        Bind<Image>(typeof(Images));

        loadBar = Get<Image>((int)Images.loadingBar);
    }

}
