using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneLoader;

public class MySceneController : MonoBehaviour
{
    [SerializeField] UI_Controller uiController;
    [SerializeField] Camera mainCamera;
    

    private void Awake()
    {
        if (SceneManager.GetSceneByName("SystemScene").isLoaded == true)
        {
            Debug.Log("Have SystemScene");
        }
        else
        {
            SceneManager.LoadSceneAsync((int)SceneIndex.SystemScene, LoadSceneMode.Additive);
            Debug.Log("Load SystemScene");
            //Init();
        }
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        CallSystemScene();

        if (uiController == null)
        {
            uiController = FindAnyObjectByType<UI_Controller>();
        }
        else
        {
            uiController.Init();
        }
    }

    void CallSystemScene()
    {
        bool hasSystemScene = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == MySceneManager.SceneIndex.SystemScene.ToString())
            {
                hasSystemScene = true;
                Debug.Log("Has System Scene");
                break;
            }
        }

        if (!hasSystemScene)
        {
            Debug.Log("dont has System Scene");

            MySceneManager.Instance.LoadSystemSceneAsync(SceneTeamSceneCallback);
        }
    }

    void SceneTeamSceneCallback()
    {

    }


}
