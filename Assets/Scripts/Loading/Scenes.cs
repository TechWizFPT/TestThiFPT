using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes : Singleton<Scenes>
{
    protected override void Start()
    {
        base.Start();
        DataGameSave.Init();
    }
    public void ChangeScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

}
public enum SceneName
{
    SystemScene,
    StartScene,
    PickHeroScene,
    GamePlayScene
}

