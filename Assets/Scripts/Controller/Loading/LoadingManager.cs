using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MySceneController
{
    [Space]
    [SerializeField] Button StartGameCoopMode;
    [SerializeField] Button StartGameOnilineMode;

    private void Awake()
    {
        StartGameCoopMode.onClick.AddListener(CoopMode);
        StartGameOnilineMode.onClick.AddListener(OnlineMode);
    }

    protected override void Start()
    {
        base.Start();

    }


    public void OnPlay()
    {
        //Scenes.Instance.ChangeScene(SceneName.PickHeroScene);
        MySceneManager.Instance.LoadingSceneAsync(MySceneManager.SceneIndex.PickHeroScene);
    }

    void CoopMode()
    {
        GameManager.Instance.currentGameMode = GameManager.GameMode.Coop;
        MySceneManager.Instance.LoadingSceneAsync(MySceneManager.SceneIndex.PickHeroScene);

    }

    void OnlineMode()
    {
        GameManager.Instance.currentGameMode = GameManager.GameMode.Online;
        MySceneManager.Instance.LoadingSceneAsync(MySceneManager.SceneIndex.PickHeroScene);

    }


    //public void QuitGame()
    //{
    //    Application.Quit();
    //}

    [ContextMenu("TestLoadScene")]
    public void TestLoadScene()
    {
        Debug.Log("Test Load Scene");
        //MySceneManager.Instance.LoadingSceneAsync(MySceneManager.SceneIndex.PickHeroScene);
        //MySceneManager.Instance.UnLoadScene(MySceneManager.SceneIndex.PickHeroScene);

        GameManager.Instance.CallGameManager();
    }


}
