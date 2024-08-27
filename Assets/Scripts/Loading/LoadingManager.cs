using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public void OnPlay()
    {
        Scenes.Instance.ChangeScene(SceneName.PickHeroScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
