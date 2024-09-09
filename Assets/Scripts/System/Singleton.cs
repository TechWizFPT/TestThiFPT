using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Component
{
    //public bool IsPersistence;

    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //Scene activeScene = SceneManager.GetActiveScene();
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("SystemScene"));
                
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                _instance = obj.AddComponent<T>();

                //SceneManager.SetActiveScene(activeScene);

            }

            return _instance;

        }

    }

    protected virtual void Awake()
    {
        //Tranh bug khi ham duoc goi o unit editor
        if(!Application.isPlaying) { return; }

        

        if (_instance == null)
        {
            _instance = this as T;
           
            //DontDestroyOnLoad(gameObject);

        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    protected virtual void Start()
    {
        bool hasSystemScene = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == MySceneManager.SceneIndex.SystemScene.ToString())
            {
                hasSystemScene = true;
                break;
            }
        }

        if (!hasSystemScene)
        {
            MySceneManager.Instance.LoadSystemSceneAsync(SceneTeamSceneCallback);
        }
        else
        {
            Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
            SceneManager.MoveGameObjectToScene(this.gameObject, targetScene);
        }

    }

    void SceneTeamSceneCallback()
    {
        //Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
        //SceneManager.MoveGameObjectToScene(this.gameObject, targetScene);
        Debug.Log("Singeton listner");
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
