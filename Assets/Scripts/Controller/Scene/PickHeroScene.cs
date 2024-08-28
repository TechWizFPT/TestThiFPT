using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickHeroScene : MonoBehaviour
{
    [SerializeField] PlayerController playerControllerPrefab;
    [SerializeField] List<PlayerController> playerControllers;
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
    
    //[SerializeField] ButtonCustom buttonStartGame;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        //Add Player
        //buttonStartGame.canClick = false;
        for (int i = 0; i < 2; i++)
        {
            var newPlayer = Instantiate(playerControllerPrefab);
            playerControllers.Add(newPlayer);

            newPlayer.playerID = i;
            //GameObject newPickCharacterController = new GameObject("Player " + newPlayer.playerID);
            var newPickCharacterController = newPlayer.AddComponent<PickHeroController>();
            newPickCharacterController.characterSlotPrefab = characterSlotPrefab;
            newPickCharacterController.playerController = newPlayer;

            newPickCharacterController.pickHeroScene = this;
            newPickCharacterController.GetTeamList(teamContainer[i]);

        }

        GetCharacterList();
    }

    void AddPlayer()
    {

    }

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
        foreach(PlayerController playerController in playerControllers)
        {
            if(!playerController.pickCharacterController.isReady)
            {
                Debug.Log("Game not ready");
                return ;
            }

        }

        startBtnLock.SetActive(false);
        //buttonStartGame.canClick = true;

        Debug.Log("Game Ready");

    }

    public void StartGame()
    {
        Scenes.Instance.ChangeScene(SceneName.GamePlayScene);
    }
}
