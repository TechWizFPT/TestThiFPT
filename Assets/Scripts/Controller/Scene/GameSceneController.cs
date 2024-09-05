using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MySceneController
{
    [SerializeField] PlayerManager playerManagerPrefab;
    [SerializeField] MyCharacterController playerControllerPrefab;

    [Space]
    public List<MyCharacterController> playerControllers = new List<MyCharacterController>();

    [SerializeField] Transform[] spawnLocation;

    [SerializeField] CameraController cameraController;

    public enum GameState
    {
        StartScene,
        StartFight,
        EndFight,

    }

    public GameState currentGameState;

    private void Awake()
    {
        //Find CameraController
        cameraController = FindAnyObjectByType<CameraController>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentGameState = GameState.StartScene;
        UpdateGameState(GameState.StartScene);

        UpdateGameState(GameState.StartFight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {

    }
    public void UpdateGameState(GameState newState)
    {
        
        switch (newState)
        {
            case GameState.StartScene:
                //SpawnCharacter
                SpawnCharacter();

                //Active CameraController
                cameraController.gameSceneController = this;
                cameraController.Init();


                //Active PlayerInput
                for (int i = 0; i < GameManager.Instance.playerManagers.Count; i++)
                {
                    GameManager.Instance.playerManagers[i].inputController.currentInputState =
                        MyPlayerInputController.InpustState.ControllCharacterState;
                }

                //Active Player
                for (int i = 0; i < playerControllers.Count; i++)
                {
                    playerControllers[i].GetTarget(playerControllers);
                }
                break;
            case GameState.StartFight:
           
                break;
            case GameState.EndFight:
                break;
        }

        currentGameState = newState;


    }
    void SpawnCharacter()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(MySceneManager.SceneIndex.GamePlayScene.ToString()));
        Debug.Log("Active scene is aaaaaaa" + SceneManager.GetActiveScene().name);

        for (int i = 0; i < GameManager.Instance.playerManagers.Count; i++)
        {
            //Quaternion rotation = Quaternion.Euler(0, 90, 0);
            var tmp = Instantiate(playerControllerPrefab, spawnLocation[i].position, Quaternion.identity);

            playerControllers.Add(tmp);

            GameManager.Instance.playerManagers[i].AddCharacterToPlayerManager(tmp);

            //tmp.playerManager = GameManager.Instance.playerManagers[i];
            //tmp.playerManager.playerID = i;

            Debug.Log("Spawn Character " + tmp.playerManager.playerID);
        }


        
        //playerControllers[0].target = playerControllers[1].transform;
        //playerControllers[1].target = playerControllers[0].transform;
    }
}
