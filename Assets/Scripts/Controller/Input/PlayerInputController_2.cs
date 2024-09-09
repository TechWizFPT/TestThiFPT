using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController_2 : MyPlayerInputController
{
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
       
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pickCharacterController.MoveCharacterSelectPointer(1);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("ChangeCharacter Panel");

            pickCharacterController.MoveCharacterSelectPointer(-1);

        }
    }

    protected override void MoveTeamPoiter()
    {
        base.MoveTeamPoiter();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var tmp = pickCharacterController.currentSlotIndex + 1;
            pickCharacterController.UpdateTeamListUI(tmp);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var tmp = pickCharacterController.currentSlotIndex - 1;
            pickCharacterController.UpdateTeamListUI(tmp);

        }
    }

    protected override void SeletedCharacterInput()
    {
        base.SeletedCharacterInput();
        if (Input.GetKeyDown(KeyCode.Return))
        {
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

        if (Input.GetKey(KeyCode.L))
        {
            //Debug.Log("Move input D");
            moveInputDir = 1;

        }
        else if (Input.GetKey(KeyCode.J))
        {
            moveInputDir = -1;

        }
        else
        {
            moveInputDir = 0;
        }

        characterController.Moving(moveInputDir);
    }
    protected override void JumpInput()
    {
        base.JumpInput();
    }

    protected override void AttackInput()
    {
        base.AttackInput();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Player 2 Attack");
            //characterController.canMove = false;
            //if (characterController.characterAnimationController != null)
            //{
            //    characterController.characterAnimationController.AttackNormalAim();

            //}

            if (characterController != null)
            {
                //characterController.canMove = false;
                characterController.AttackNormal();

            }

        }


        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Debug.Log("Player 2 AttackHard input");
            if (characterController != null)
            {
                //characterController.canMove = false;
                characterController.AttackHard();

            }
        }
    }

    protected override void GuardInput()
    {
        base.GuardInput();
    }

}
