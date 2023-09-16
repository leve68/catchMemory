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
        //Init()  이 Init함수는 loadingScene에서 호출해줌 (이유: LoadingScene 런타임보다 빠르게 UI완성 필요)
    }
    public override void Init()
    {
        Bind<Image>(typeof(Images));

        loadBar = Get<Image>((int)Images.loadingBar);
    }

}
