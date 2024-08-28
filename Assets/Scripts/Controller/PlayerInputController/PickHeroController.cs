using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PickHeroController : MonoBehaviour
{

    public PlayerController playerController;
    public PickHeroScene pickHeroScene;
    bool _isReady;
    public bool isReady { get { return _isReady; } }

    [Space]
    public CharacterSlot characterSlotPrefab;

    public List<CharacterSlot> characterSlots = new List<CharacterSlot>();

    [SerializeField] int currentSlotIndex;

    //[SerializeField] CharacterSlot currentslot;

    [SerializeField] int seletedCharacterIndex;

    //[Space]
    //public List<CharacterData> pickedCharacterList;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerController.pickCharacterController = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ChangePickSlot();
        ChangeCharacterSelectedIndex();

        //Seleted Character
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerController.playerID == 0)
            {
                SelectedCharacter();

            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Test");
            if (playerController.playerID == 1)
            {
                SelectedCharacter();
            }
        }
    }

    void Init()
    {
        currentSlotIndex = 0;
        characterSlots[currentSlotIndex].Seleted();

        seletedCharacterIndex = 0;
        pickHeroScene.CharacterPanelSeleted(0, seletedCharacterIndex, playerController.playerID);


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

    void ChangePickSlot()
    {
        if (playerController.playerID == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                characterSlots[currentSlotIndex].UnSeleted();
                currentSlotIndex = currentSlotIndex + 1 < characterSlots.Count ? currentSlotIndex + 1 : 0;
                characterSlots[currentSlotIndex].Seleted();

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                characterSlots[currentSlotIndex].UnSeleted();
                currentSlotIndex = currentSlotIndex - 1 >= 0 ? currentSlotIndex - 1 : characterSlots.Count - 1;
                characterSlots[currentSlotIndex].Seleted();

            }
        }

        if (playerController.playerID == 1)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                characterSlots[currentSlotIndex].UnSeleted();
                currentSlotIndex = currentSlotIndex + 1 < characterSlots.Count ? currentSlotIndex + 1 : 0;
                characterSlots[currentSlotIndex].Seleted();

            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                characterSlots[currentSlotIndex].UnSeleted();
                currentSlotIndex = currentSlotIndex - 1 >= 0 ? currentSlotIndex - 1 : characterSlots.Count - 1;
                characterSlots[currentSlotIndex].Seleted();

            }
        }
    }


    void ChangeCharacterSelectedIndex()
    {
        if (playerController.playerID == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("ChangeCharacter Panel");

                int tmp = seletedCharacterIndex;
                seletedCharacterIndex = seletedCharacterIndex - 1 >= 0 ?
                    seletedCharacterIndex - 1 : pickHeroScene.characterPanels.Count - 1;
                pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerController.playerID);

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                int tmp = seletedCharacterIndex;
                seletedCharacterIndex = seletedCharacterIndex + 1 < pickHeroScene.characterPanels.Count ?
                    seletedCharacterIndex + 1 : 0;
                pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerController.playerID);

            }
        }

        if (playerController.playerID == 1)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("ChangeCharacter Panel");

                int tmp = seletedCharacterIndex;
                seletedCharacterIndex = seletedCharacterIndex - 1 >= 0 ?
                    seletedCharacterIndex - 1 : pickHeroScene.characterPanels.Count - 1;
                pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerController.playerID);

            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                int tmp = seletedCharacterIndex;
                seletedCharacterIndex = seletedCharacterIndex + 1 < pickHeroScene.characterPanels.Count ?
                    seletedCharacterIndex + 1 : 0;
                pickHeroScene.CharacterPanelSeleted(tmp, seletedCharacterIndex, playerController.playerID);

            }
        }
    }


    void SelectedCharacter()
    {
        Debug.Log("Pick Character");
        characterSlots[currentSlotIndex].AddCharacter(pickHeroScene.characterPanels[seletedCharacterIndex].characterData);

        if (characterSlots[0].characterData != null && characterSlots[1].characterData)
        {
            Debug.Log("Player ready");
            _isReady = true;
        }

        pickHeroScene.PlayerPickCharacter();
    }
}
