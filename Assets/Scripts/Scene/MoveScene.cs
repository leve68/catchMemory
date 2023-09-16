using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public GameObject settingPannel;
    public GameObject loadPannel;

    public void gotoStage1()
    {
        SceneManager.LoadScene("Stage1");
    }   

    public void openSetting()
    {
        settingPannel.SetActive(true);
    }
    public void closeSetting()
    {
        settingPannel.SetActive(false);
    }

    public void openLoad()
    {
        loadPannel.SetActive(true);
    }

    public void closeLoad()
    {
        loadPannel.SetActive(false);
    }
}