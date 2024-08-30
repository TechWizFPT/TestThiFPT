using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    EventSystem uiEventSystem;
    [SerializeField] protected Canvas uiCanvas;

    private void Awake()
    {
        
    }
    protected virtual void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InitAwake()
    {

    }

    public void Init()
    {        

        if (FindAnyObjectByType<EventSystem>() == null)
        {
            var eventSystem = Instantiate(new GameObject());
            eventSystem.AddComponent<EventSystem>();
        }
        
    }

       
    public virtual void TurnOffEventSystem()
    {
        uiEventSystem.gameObject.SetActive(false);
    }

    public virtual void TurnOnEventSystem()
    {
        uiEventSystem.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUit game");
        Application.Quit();
    }
}
