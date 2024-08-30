using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadLevelAsync(SceneName scenename, Animator animator)
    {
        animator.Play("CrossFade_End");
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename.ToString());
        while (!operation.isDone)
        {
            yield return null;
        }

    }
}
