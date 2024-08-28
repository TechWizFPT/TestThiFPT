using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes : Singleton<Scenes>
{
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
