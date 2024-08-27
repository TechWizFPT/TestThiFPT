using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHeroScene : MonoBehaviour
{
    [SerializeField] PlayerController playerControllerPrefab;
    [SerializeField] List<PlayerController> playerControllers;

    [SerializeField] GameObject [] teamContainer;

    [Space]
    [SerializeField] GameObject characterContainer;
    [SerializeField] CharacterPanel characterPanelPrefab;
    public List<CharacterPanel> characterPanels;

    [Space]
    [SerializeField] List<CharacterData> listCharacterData;
    //[SerializeField] public Action<int,int,int> seletedCharacterListener;

    [SerializeField] GameObject startBtnLock;

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
        for(int i = 0; i < 2; i++)
        {
            var newPlayer = Instantiate(playerControllerPrefab);
            newPlayer.playerID = i;
            newPlayer.GetComponent<PickHeroController>().GetTeamList(teamContainer[i]);
            newPlayer.GetComponent<PickHeroController>().pickHeroScene = this;

            playerControllers.Add(newPlayer);
        }

        GetCharacterList();
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


        Debug.Log("Game Ready");


    }
}
