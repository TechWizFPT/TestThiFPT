using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadListener : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("SceneLoad Listener");
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveSceneController()
    {
        Debug.Log("Active SceneLoad Listener ");
        this.gameObject.SetActive(true);
    }

    IEnumerator CheckIsActiveScene()
    {
        Scene tmp = gameObject.scene;
        while (SceneManager.GetActiveScene().ToString() != tmp.ToString())
        {
            //this.enabled = false;
            gameObject.SetActive(false);
            Debug.Log("Scene it not active");
            yield return new WaitForEndOfFrame();
        }

        //this.enabled = true;
        gameObject.SetActive(true);

        Debug.Log("active Game object Scene Controller " + gameObject.scene.name);
    }
}
