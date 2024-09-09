using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MySceneController
{
    [SerializeField] PlayerManager playerManagerPrefab;
    [SerializeField] CharacterControllerModified playerControllerPrefab;

    [Space]
    public List<CharacterControllerModified> playerControllers = new List<CharacterControllerModified>();

    [SerializeField] Transform[] spawnLocation;

    [SerializeField] CameraController cameraController;

    [SerializeField] int player1PointCount;
    [SerializeField] int player2PointCount;

    public enum GameState
    {
        StartScene,
        StartFight,
        EndFight,

    }

    public GameState currentGameState;

    protected override void Awake()
    {
        base.Awake();
        //Find CameraController
        Debug.Log("Find camera Controller");
    }


    private void OnEnable()
    {
        cameraController = FindObjectOfType<CameraController>();

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
                Debug.Log("End Fight ");

                break;
        }

        currentGameState = newState;


    }
    void SpawnCharacter()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(MySceneManager.SceneIndex.GamePlayScene.ToString()));
        //Debug.Log("Active scene is aaaaaaa" + SceneManager.GetActiveScene().name);

        for (int i = 0; i < GameManager.Instance.playerManagers.Count; i++)
        {
            //Quaternion rotation = Quaternion.Euler(0, 90, 0);
            var tmp = Instantiate(playerControllerPrefab, spawnLocation[i].position, Quaternion.identity);

            tmp.gameSceneController = this; 

            playerControllers.Add(tmp);

            GameManager.Instance.playerManagers[i].AddCharacterToPlayerManager(tmp);

            //tmp.playerManager = GameManager.Instance.playerManagers[i];
            //tmp.playerManager.playerID = i;

            Debug.Log("Spawn Character " + tmp.playerManager.playerID);
        }

    }

    public void EndFight(PlayerManager playerLose)
    {
        if(currentGameState != GameState.EndFight)
        {
            UpdateGameState(GameState.EndFight);
            UpdatePoint(playerLose);

            Debug.Log("Player " + playerLose.name + " lose!");
        }
    }

    void UpdatePoint(PlayerManager playerLose)
    {
        if(playerLose.playerID == 0)
        {
            player2PointCount++;
        }
        else
        {
            player1PointCount++;
        }

        if((player2PointCount >1) || (player1PointCount > 1))
        {
            Debug.Log("Game End GO NExt Game");
        }
    }
}
