using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    List<AsyncOperation> sceneLoadingList = new List<AsyncOperation>();

    AsyncOperation loadingAsynOperation;

    [SerializeField] GameObject loadingSceen;
    [SerializeField] Slider loadingBar;

    public enum SceneIndex
    {
        SystemScene ,
        LoadingScene,
        LoginScene ,
        LobbyScene,
        StartScene,

    }

    SceneIndex currentScene;
    public SceneIndex lastScene;


    // Start is called before the first frame update
    private void Awake()
    {
        if(SceneManager.sceneCount <2)
        {
            LoadingSceneAsync(SceneIndex.LoginScene);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.U))
        //{
        //    UnLoadScene(SceneIndex.LoginScene);
        //}
    }

    public void LoadingSceneAsync(SceneIndex sceneIndex)
    {
        //SceneManager.LoadSceneAsync((int)SceneIndex.LoginScene, LoadSceneMode.Additive);

        //sceneLoadingList.Add(SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive));

        loadingSceen.SetActive(true);

        //loadingAsynOperation = SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive);
       
        StartCoroutine(LoadingProgress(sceneIndex));

    }

    public void SwitchSceneAsync(SceneIndex sceneIndex)
    {        
        loadingSceen.SetActive(true);

        StartCoroutine(LoadingProgress(sceneIndex));
        SceneManager.UnloadSceneAsync((int)currentScene);

    }

    public void UnLoadScene(SceneIndex sceneIndex)
    {
        SceneManager.UnloadSceneAsync((int)sceneIndex);
        Debug.Log("Last scene" + lastScene);
        Debug.Log("CurrentScene" + currentScene);
        Debug.Log("Unload Scene" + sceneIndex.ToString());

    }

    public IEnumerator LoadingProgress(SceneIndex sceneIndex)
    {
        lastScene = currentScene;
        loadingAsynOperation = SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive);
        currentScene = sceneIndex;

        while (!loadingAsynOperation.isDone)
        {
            loadingBar.value = GetLoadingProgress();
            yield return null;
        }
        loadingBar.value = GetLoadingProgress();
        
        loadingSceen.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Kiểm tra xem đối tượng cần tìm có trong scene không
        GameObject myObject = GameObject.Find("MyObject");

        if (myObject != null)
        {
            Debug.Log("Found MyObject in scene: " + scene.name);
            // Thực hiện các thao tác khác với đối tượng nếu cần
        }
        else
        {
            Debug.Log("MyObject not found in scene: " + scene.name);
        }
    }

    public float GetLoadingProgress()
    {
        if(loadingAsynOperation != null)
        {
            return loadingAsynOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    //public IEnumerator LoadingProgress()
    //{
    //    for (int i = 0; i < sceneLoadingList.Count; i++)
    //    {
    //        while (!sceneLoadingList[i].isDone)
    //        {
    //            yield return null;
    //        }
    //    }
    //}
}
