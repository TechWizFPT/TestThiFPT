using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController_1 : MyPlayerInputController
{
    //public int moveInputDir;
    private void Awake()
    {
        //characterController = GetComponent<MyCharacterController>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentInputState)
        {
            case InpustState.PickCharacterState:
                SeletedCharacterInput();
                MoveTeamPoiter();
                MoveCharacterPoiter();

                break;
            case InpustState.ControllCharacterState:
                MoveInput();
                AttackInput();
                break;
        }
        
    }

    //PickCharacterController
    protected override void MoveCharacterPoiter()
    {
        base.MoveCharacterPoiter();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("ChangeCharacter Panel");

            pickCharacterController.MoveCharacterSelectPointer(-1);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pickCharacterController.MoveCharacterSelectPointer(1);

        }
    }

    protected override void MoveTeamPoiter()
    {
        base.MoveTeamPoiter();

        if (Input.GetKeyDown(KeyCode.E))
        {
            var tmp = pickCharacterController.currentSlotIndex + 1;
            pickCharacterController.UpdateTeamListUI(tmp);

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            var tmp = pickCharacterController.currentSlotIndex - 1;
            pickCharacterController.UpdateTeamListUI(tmp);

        }

    }

    protected override void SeletedCharacterInput()
    {
        base.SeletedCharacterInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player 1 Seleted Character");
            pickCharacterController.SelectedCharacter();

        }
    }

    // CharacterController
    protected override void MoveInput()
    {
        base.MoveInput();

        if (!characterController.canMove)
        {
            moveInputDir = 0;
            characterController.Moving(moveInputDir);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Move input D");
            moveInputDir = 1;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveInputDir = -1;

        }
        else
        {
            moveInputDir = 0;
        }
     
        characterController.Moving(moveInputDir);
    }

    protected override void AttackInput()
    {
        base.AttackInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player 1 Attack");
            characterController.canMove = false;

            if (characterController.characterAnimationController != null)
            {
                characterController.characterAnimationController.AttackAim();

            }
        }
    }

    protected override void DefenseInput()
    {
        base.DefenseInput();
    }

    protected override void JumpInput()
    {
        base.JumpInput();
    }


}
