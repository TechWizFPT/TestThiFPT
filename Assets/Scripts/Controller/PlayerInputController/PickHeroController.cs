using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MyCharacterController))]
public class PickHeroController : MonoBehaviour
{
    public PlayerManager playerManager;
    public PickHeroSceneController pickHeroScene;

    bool _isReady;
    public bool isReady { get { return _isReady; } }

    [Space]
    public CharacterSlot characterSlotPrefab;

    public List<CharacterSlot> characterSlots = new List<CharacterSlot>();

    public int currentSlotIndex;

    //[SerializeField] CharacterSlot currentslot;

    [SerializeField] int seletedCharacterIndex;

    //[Space]
    //public List<CharacterData> pickedCharacterList;

    private void Awake()
    {
        //playerManager = GetComponent<MyCharacterController>();
        //playerManager.pickCharacterController = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        //ChangePickSlot();

        //ChangeCharacterSelectedIndex();
       
        ////Seleted Character
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (playerManager.playerID == 0)
        //    {
        //        SelectedCharacter();

        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    //Debug.Log("Test");
        //    if (playerManager.playerID == 1)
        //    {
        //        SelectedCharacter();
        //    }
        //}
    }

    void Init()
    {
        currentSlotIndex = 0;
        characterSlots[currentSlotIndex].Seleted();

        seletedCharacterIndex = 0;
        pickHeroScene.CharacterPanelSeleted(0, seletedCharacterIndex, playerManager.playerID);


    }
    public void GetTeamList(GameObject container)
    {
        characterSlots.Clear();

        //if (characterSlots.Count > 0)
        //{
        //    characterSlots.Clear();

        //}

        for (int i = 0; i < 2; i++)
        {
            var newCharacterSlot = Instantiate(characterSlotPrefab, container.transform);
            characterSlots.Add(newCharacterSlot);
        }

    }

    public void UpdateTeamListUI( int newIndex)
    {
        characterSlots[currentSlotIndex].UnSeleted();
        
        if(newIndex >= characterSlots.Count)
        {
            newIndex = 0;
        }

        if(newIndex < 0)
        {
            newIndex = characterSlots.Count - 1;
        }

        currentSlotIndex = newIndex;
        characterSlots[currentSlotIndex].Seleted();


    }

    void ChangePickSlot()
    {
        //if (playerManager.playerID == 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        characterSlots[currentSlotIndex].UnSeleted();
        //        currentSlotIndex = currentSlotIndex + 1 < characterSlots.Count ? currentSlotIndex + 1 : 0;
        //        characterSlots[currentSlotIndex].Seleted();

        //    }

        //    if (Input.GetKeyDown(KeyCode.Q))
        //    {
        //        characterSlots[currentSlotIndex].UnSeleted();
        //        currentSlotIndex = currentSlotIndex - 1 >= 0 ? currentSlotIndex - 1 : characterSlots.Count - 1;
        //        characterSlots[currentSlotIndex].Seleted();

        //    }



        //}

        //if (playerManager.playerID == 1)
        //{
        //    if (Input.GetKeyDown(KeyCode.U))
        //    {
        //        characterSlots[currentSlotIndex].UnSeleted();
        //        currentSlotIndex = currentSlotIndex + 1 < characterSlots.Count ? currentSlotIndex + 1 : 0;
        //        characterSlots[currentSlotIndex].Seleted();

        //    }

        //    if (Input.GetKeyDown(KeyCode.O))
        //    {
        //        characterSlots[currentSlotIndex].UnSeleted();
        //        currentSlotIndex = currentSlotIndex - 1 >= 0 ? currentSlotIndex - 1 : characterSlots.Count - 1;
        //        characterSlots[currentSlotIndex].Seleted();

        //    }
        //}
    }

    public void MoveCharacterSelectPointer(int newNum )
    {
        int tmp = seletedCharacterIndex;
        seletedCharacterIndex += newNum;
        if(seletedCharacterIndex < 0)
        {
            seletedCharacterIndex = pickHeroScene.characterPanels.Count - 1;
        }

        if(seletedCharacterIndex >= pickHeroScene.characterPanels.Count)
        {
            seletedCharacterIndex = 0;
        }

        pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerManager.playerID);

    }


    void ChangeCharacterSelectedIndex()
    {
        //if (playerManager.playerID == 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        Debug.Log("ChangeCharacter Panel");

        //        int tmp = seletedCharacterIndex;
        //        seletedCharacterIndex = seletedCharacterIndex - 1 >= 0 ?
        //            seletedCharacterIndex - 1 : pickHeroScene.characterPanels.Count - 1;
        //        pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerManager.playerID);

        //    }

        //    if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        int tmp = seletedCharacterIndex;
        //        seletedCharacterIndex = seletedCharacterIndex + 1 < pickHeroScene.characterPanels.Count ?
        //            seletedCharacterIndex + 1 : 0;
        //        pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerManager.playerID);

        //    }
        //}

        //if (playerManager.playerID == 1)
        //{
        //    if (Input.GetKeyDown(KeyCode.J))
        //    {
        //        Debug.Log("ChangeCharacter Panel");

        //        int tmp = seletedCharacterIndex;
        //        seletedCharacterIndex = seletedCharacterIndex - 1 >= 0 ?
        //            seletedCharacterIndex - 1 : pickHeroScene.characterPanels.Count - 1;
        //        pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerManager.playerID);

        //    }

        //    if (Input.GetKeyDown(KeyCode.L))
        //    {
        //        int tmp = seletedCharacterIndex;
        //        seletedCharacterIndex = seletedCharacterIndex + 1 < pickHeroScene.characterPanels.Count ?
        //            seletedCharacterIndex + 1 : 0;
        //        pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerManager.playerID);

        //    }
        //}
    }


    public void SelectedCharacter()
    {
        Debug.Log("Pick Character");
        //Update UI
        characterSlots[currentSlotIndex].AddCharacter(pickHeroScene.characterPanels[seletedCharacterIndex].characterData);
               
        //Add CharacterData to team list
        if (playerManager.teamList.Count > currentSlotIndex)    
        {
            playerManager.teamList[currentSlotIndex] = characterSlots[currentSlotIndex].characterData;
        }
        else
        {
            playerManager.teamList.Add(characterSlots[currentSlotIndex].characterData);
        }


        //Check full team 
        if (characterSlots[0].characterData != null && characterSlots[1].characterData)
        {
            Debug.Log("Player ready");
            _isReady = true;
        }

        pickHeroScene.PlayerPickCharacter();
    }

    public void DestroySelf()
    {
        Destroy(this);
    }
}
