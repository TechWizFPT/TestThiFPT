using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPause : Popups
{
    static PopupPause instance;
    public static void Show()
    {
        if(instance==null)
        {
            instance = Instantiate(PopupConfig.Instance.popupPause, GameObject.FindWithTag("CanvasPopup").transform);
            instance.Appear();
            instance.Init();
        }
        else
        {
            instance.Appear();
            instance.Init();
        }
    }
    public void Init()
    {

    }
    public void ResumeGame()
    {
        
        Disappear(()=>
        {
            Time.timeScale = 1;
        });
    }
    public void GoHome()
    {
        Scenes.Instance.ChangeScene(SceneName.StartScene);
    }
}
