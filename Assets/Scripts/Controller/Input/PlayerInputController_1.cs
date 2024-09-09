using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController_1 : MyPlayerInputController
{
    //public int moveInputDir;
    private void Awake()
    {
        //characterController = GetComponent<CharacterControllerModified>();  
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
                GuardInput();
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
            //Debug.Log("Player 1 Attack");
            if (characterController != null)
            {
                //characterController.canMove = false;
                characterController.AttackNormal();

            }

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Player 1 AttackHard input");
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
        if(Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Guard(true);
            Debug.Log("Guard Input");
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("No Guard Input");

            characterController.Guard(false);
        }

        //if(Input.GetKeyUp(KeyCode.LeftShift))
    }

    protected override void JumpInput()
    {
        base.JumpInput();
    }


}
