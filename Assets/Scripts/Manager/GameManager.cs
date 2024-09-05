using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        playerManagers = new List<PlayerManager>();

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

    void CreateNewPlayerManager()
    {

    }

    public void CallGameManager()
    {
        Debug.Log("Game Manager call");
    }

    public void GetGameMode()
    {
        int numPlayer = 0;

        switch (GameManager.Instance.currentGameMode)
        {
            case GameManager.GameMode.Coop:
                numPlayer = 2;
                break;
            case GameManager.GameMode.Online:
                numPlayer = 1;
                break;
        }

        //Scene activeScene = SceneManager.GetActiveScene();
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("SystemScene"));
        for (int i = 0; i < numPlayer; i++)
        {
            AddPlayer();
        }
        //SceneManager.SetActiveScene(activeScene);

    }

    public void AddPlayer()
    {
        GameObject newPlayerManager = new GameObject();
        var tmp = newPlayerManager.AddComponent<PlayerManager>();

        //if (playerManagers == null)
        //{
        //    playerManagers = new List<PlayerManager>();

        //}

        playerManagers.Add(tmp);
        tmp.playerID = playerManagers.IndexOf(tmp);
        newPlayerManager.name = typeof(PlayerManager).Name + playerManagers.IndexOf(tmp);

        AddInputController(tmp);

    }


    void AddInputController(PlayerManager playerManager)
    {
        if (playerManager.playerID == 0)
        {
            var newPlayerInput = playerManager.gameObject.AddComponent<PlayerInputController_1>();

            playerManager.inputController = newPlayerInput;
        }

        if (playerManager.playerID == 1)
        {
            //inputController.AddComponent<PlayerInputController_2>();
            var newPlayerInput2 = playerManager.gameObject.AddComponent<PlayerInputController_2>();

            playerManager.inputController = newPlayerInput2;
        }
    }
}
