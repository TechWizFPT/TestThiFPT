using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int playerID;
    public MyPlayerInputController inputController;

    public List<CharacterData> teamList;
    public MyCharacterController currentCharacterController;

    private void Awake()
    {
        //inputController = GetComponent<MyPlayerInputController>();
        teamList = new List<CharacterData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
        SceneManager.MoveGameObjectToScene(this.gameObject, targetScene);

        //if (inputController == null)
        //{
        //    if (playerID == 0)
        //    {
        //        gameObject.AddComponent<PlayerInputController_1>();

        //        inputController = GetComponent<PlayerInputController_1>();
        //    }

        //    if (playerID == 1)
        //    {
        //        //inputController.AddComponent<PlayerInputController_2>();
        //        gameObject.AddComponent<PlayerInputController_2>();

        //        inputController = GetComponent<PlayerInputController_2>();
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCharacterToPlayerManager(MyCharacterController characterController)
    {
        currentCharacterController = characterController;
        currentCharacterController.playerManager = this;

        AddCharacterToInputController(characterController);
    }

    public void AddCharacterToInputController(MyCharacterController characterController)
    {
        //if(inputController == null)
        //{
        //    if(playerID == 0)
        //    {
        //        gameObject.AddComponent<PlayerInputController_1>();

        //        inputController = GetComponent<PlayerInputController_1>();
        //    }

        //    if (playerID == 1) {
        //        //inputController.AddComponent<PlayerInputController_2>();
        //        gameObject.AddComponent<PlayerInputController_2>();

        //        inputController = GetComponent<PlayerInputController_2>();
        //    }
        //}
        inputController.characterController = characterController;
    }
}
