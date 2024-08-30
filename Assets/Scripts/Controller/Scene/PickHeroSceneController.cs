using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickHeroSceneController : MySceneController
{
    [SerializeField] PlayerManager playerManagerPrefab;
    [SerializeField] List<PickHeroController> pickHeroControllers;

    //[SerializeField] List<PickHeroController> pickHeroControllers;
    
    [Space]
    public CharacterSlot characterSlotPrefab;
    [SerializeField] GameObject [] teamContainer;

    [Space]
    [SerializeField] GameObject characterContainer;
    [SerializeField] CharacterPanel characterPanelPrefab;
    public List<CharacterPanel> characterPanels;

    [Space]
    [SerializeField] List<CharacterData> listCharacterData;
    //[SerializeField] public Action<int,int,int> seletedCharacterListener;

    [SerializeField] GameObject startBtnLock;

    [SerializeField] Button startBtn;

    //Test
    [SerializeField] ButtonCustom buttonStartGame;

    private void Awake()
    {
       
    }
    protected override void Start()
    {
        base.Start();
        Init();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGameTest()
    {
        Debug.Log("Test");
        MySceneManager.Instance.LoadingSceneAsync(MySceneManager.SceneIndex.GamePlayScene);
    }

    void Init()
    {
        //startBtn.enabled = false;
        //startBtn.onClick.AddListener(StartGameTest);

        //Add Player
        buttonStartGame.canClick = false;

        AddPlayer();

        GetCharacterList();
    }

    void AddPlayer()
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


        //Spawn player
        for (int i = 0; i < numPlayer; i++)
        {
            //Spawn PLayerManager
            var newPlayer = Instantiate(playerManagerPrefab);
            newPlayer.playerID = i;
            Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
            SceneManager.MoveGameObjectToScene(newPlayer.gameObject, targetScene);
            GameManager.Instance.playerManagers.Add(newPlayer);

            //playerControllers.Add(newPlayer);


            //Spawn PickheroController
            GameObject newPickHeroController = new GameObject("PickHeroController_" + i);
            newPickHeroController.transform.parent = this.transform;
            var newPickCharacterController = newPickHeroController.AddComponent<PickHeroController>();

            pickHeroControllers.Add(newPickCharacterController);
            newPickCharacterController.characterSlotPrefab = characterSlotPrefab;
            newPickCharacterController.playerManager = newPlayer;

            newPickCharacterController.pickHeroScene = this;
            newPickCharacterController.GetTeamList(teamContainer[i]);

            Debug.Log("Add player " + newPlayer.playerID);

        }


    }

    //Show All Character In game
    void GetCharacterList()
    {
        characterPanels.Clear();

        foreach(CharacterData characterData in listCharacterData)
        {
            var newCharacterPanel =  Instantiate(characterPanelPrefab,characterContainer.transform);
            newCharacterPanel.gameObject.SetActive(true);
            newCharacterPanel.characterData = characterData;
            characterPanels.Add(newCharacterPanel);
        }
    }

    public void CharacterPanelSeleted(int oldPanelIndex, int newPanelIndex,int playerID)
    {
        characterPanels[oldPanelIndex].UnSeleted(playerID);
        characterPanels[newPanelIndex].Seleted(playerID);

    }

    public void PlayerPickCharacter()
    {
        foreach(PickHeroController pickHeroController in pickHeroControllers)
        {
            if(!pickHeroController.isReady)
            {
                Debug.Log("Game not ready");
                return ;
            }

        }

        startBtnLock.SetActive(false);
        //startBtn.enabled = true;

        buttonStartGame.canClick = true;

        Debug.Log("Game Ready");

    }

    public void StartGame()
    {
        //Scenes.Instance.ChangeScene(SceneName.GamePlayScene);
        foreach(PickHeroController pickHeroController in pickHeroControllers)
        {
           
            pickHeroController.DestroySelf();
        }

        MySceneManager.Instance.LoadingSceneAsync(MySceneManager.SceneIndex.GamePlayScene);

    }

   
}
