using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerInputController : MonoBehaviour
{
    public PickHeroController pickCharacterController;
    public CharacterControllerModified characterController;

    public int moveInputDir;
    public enum InpustState{
        PickCharacterState,
        ControllCharacterState,
    }

    public InpustState currentInputState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveInput();
        //AttackInput();
        //SeletedCharacterInput();
    }
      
    //PickHeroController input
    protected virtual void MoveTeamPoiter()
    {

    }

    protected virtual void MoveCharacterPoiter()
    {

    }

    protected virtual void SeletedCharacterInput()
    {

    }

    //CharacterController Inputs
    protected virtual void MoveInput()
    {

    }

    protected virtual void AttackInput()
    {

    }

    protected virtual void JumpInput()
    {

    }

    protected virtual void GuardInput()
    {

    }
}
