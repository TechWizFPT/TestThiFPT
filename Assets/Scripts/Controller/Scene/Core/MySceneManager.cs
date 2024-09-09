using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class MySceneManager : Singleton<MySceneManager>
{
    List<AsyncOperation> sceneLoadingList = new List<AsyncOperation>();

    //public Action SystemSceneCallback;
    public enum SceneIndex
    {
        SystemScene,
        LoadingScene,
        LoginScene,
        LobbyScene,
        StartScene,
        PickHeroScene,
        GamePlayScene,
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadScene(SceneIndex sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex.ToString());
    }

    public void LoadSystemSceneAsync(Action SystemSceneCallback)
    {
        //SceneManager.LoadSceneAsync(SceneIndex.SystemScene.ToString(), LoadSceneMode.Additive);
        StartCoroutine(LoadSystemScene(SystemSceneCallback));
    }

    public IEnumerator LoadSystemScene(Action systemSceneCallback)
    {
        AsyncOperation asyncOperation =
            SceneManager.LoadSceneAsync(SceneIndex.SystemScene.ToString(), LoadSceneMode.Additive); ;

        while (!asyncOperation.isDone)
        {
            yield return null;

        }

        Debug.Log("Active scene is: " + SceneManager.GetActiveScene().name);

        Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
        SceneManager.MoveGameObjectToScene(this.gameObject, targetScene);
        systemSceneCallback?.Invoke();

    }


    //Cai nay load scene target + them system scene
    public void LoadingSceneAsync(SceneIndex sceneIndex)
    {

        //SceneManager.LoadSceneAsync(sceneIndex.ToString(), LoadSceneMode.Additive);

        StartCoroutine(LoadingSceneAsyncCallback(sceneIndex));

    }

    public IEnumerator LoadingSceneAsyncCallback(SceneIndex sceneIndex)
    {
        //LoadNewScene
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex.ToString(), LoadSceneMode.Additive);

        Debug.Log("Load Scene " + sceneIndex.ToString());
        Debug.Log("Current Active scene is " + SceneManager.GetActiveScene().name);

        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex.ToString());
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        //while (!asyncOperation.isDone)
        //{
        //    yield return null;

        //}

        Scene loadedScene = SceneManager.GetSceneByName(sceneIndex.ToString());

        if (loadedScene.isLoaded)
        {
            //Disable All Script 
            foreach (GameObject obj in loadedScene.GetRootGameObjects())
            {
                DisableAllScripts(obj);
            }
        }

        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //Debug.Log( "Loading progress: " + (asyncOperation.progress * 100) + "%");

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                Debug.Log("Press the space bar to continue");
                //Wait to you press the space key to activate the Scene

                //if (Input.GetKeyDown(KeyCode.Space))
                //    //Activate the Scene
                //    asyncOperation.allowSceneActivation = true;

                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }



        //Just keep newScene and system scene
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene tmp = SceneManager.GetSceneAt(i);

            //UnLoadScene(tmp.name);

            if ((tmp.name != SceneIndex.SystemScene.ToString()) && tmp.name != sceneIndex.ToString())
            {
                Debug.Log("Nhung Scene dang active Scene name : " + tmp.name);

                UnLoadScene(tmp.name);
            }
        }

        //Change active scene
        if (sceneIndex != SceneIndex.SystemScene)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneIndex.ToString()));
        }
        Debug.Log("Active scene is " + SceneManager.GetActiveScene().name);

        if (asyncOperation.isDone)
        {
            Scene scene = SceneManager.GetSceneByName(sceneIndex.ToString());

            GameObject[] rootObjects = scene.GetRootGameObjects();

            foreach (GameObject rootObject in rootObjects)
            {
                var tmp = rootObject.GetComponent<SceneLoadListener>();

                if (tmp != null)
                {
                    tmp.ActiveSceneController();
                    break;
                }
            }
        }

        //Active All Script again
        foreach (GameObject obj in loadedScene.GetRootGameObjects())
        {
            EnableAllScripts(obj);
        }

    }

    void DisableAllScripts(GameObject obj)
    {
        MonoBehaviour[] scripts = obj.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }

    void EnableAllScripts(GameObject obj)
    {
        MonoBehaviour[] scripts = obj.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
    }

    public void UnLoadScene(SceneIndex sceneIndex)
    {
        SceneManager.UnloadSceneAsync(sceneIndex.ToString());

    }
    public void UnLoadScene(string sceneName)
    {
        Debug.Log("Unload scene" + sceneName);
        SceneManager.UnloadSceneAsync(sceneName);

    }


    public void SwitchSceneAsync(SceneIndex sceneIndex)
    {
        //loadingSceen.SetActive(true);

        //StartCoroutine(LoadingProgress(sceneIndex));
        //SceneManager.UnloadSceneAsync((int)currentScene);

    }




}
