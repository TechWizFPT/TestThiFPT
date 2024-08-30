using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameMode
    {
        Coop,
        Online,
    }

    public GameMode currentGameMode;

    public List<PlayerManager> playerManagers;

    protected override void Awake()
    {
        //IsPersistence = true;
        base.Awake();
    }
    // Start is called before the first frame update
    protected override void  Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNewPlayerManager()
    {

    }

    public void CallGameManager()
    {
        Debug.Log("Game Manager call");
    }
}
