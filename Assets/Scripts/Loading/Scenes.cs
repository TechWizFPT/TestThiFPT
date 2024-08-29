using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes : Singleton<Scenes>
{
    private void Start()
    {
        DataGameSave.Init();
    }
    public void ChangeScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

}
public enum SceneName
{
    StartScene,
    PickHeroScene,
    GamePlayScene
}
