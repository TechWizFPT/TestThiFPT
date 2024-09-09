using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerModified : MonoBehaviour
{
    public PlayerManager playerManager;
    [HideInInspector] public GameSceneController gameSceneController;
    //public MyPlayerInputController inputController;

    //public PickHeroController pickCharacterController;
    public CharacterAnimationController characterAnimationController;
    
    [Space]
    public bool canMove;
    [SerializeField] bool isJump;
    [SerializeField] bool isMove;
    [SerializeField] bool isGuard;

    [Space]
    float lookAtDir;
    public Transform target;

    //Attack Hit box 
    [Space]
    [SerializeField] AttackMachineController normalAttackAMC;
    [SerializeField] AttackMachineController hardAttackAMC;

    //Player Stats
    [Space]
    [SerializeField] float maxHp;
    [SerializeField] float currentHp;
    [SerializeField] float moveSpeed = 1;
    //public int moveInputDir;


    float attackTimer;
    int attackCount;


    private void Awake()
    {
        //pickCharacterController = GetComponent<PickHeroController>();
        characterAnimationController = GetComponentInChildren<CharacterAnimationController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;
        canMove = true;

        maxHp = 100;
        currentHp = maxHp;

        //if (playerManager == null)
        //{
        //    playerManager = gameObject.AddComponent<PlayerManager>();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //MoveInput();

        //Ham nay can chi nen duoc goi khi co input .                     
        RotateCharacter();

        //AttackInput();

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        //Cai nay phai ben animationController
        if (characterAnimationController != null)
        {
            characterAnimationController.MoveAnim(playerManager.inputController.moveInputDir * lookAtDir);
        }
    }

    void Init()
    {

    }

    public void GetTarget(List<CharacterControllerModified> targetList)
    {
        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i] != this)
            {
                target = targetList[i].transform;
            }

        }
    }

    //void MoveInput()
    //{

    //    if (!canMove)
    //    {
    //        moveInputDir = 0;
    //        Moving(moveInputDir);
    //        return;
    //    }

    //    if (playerManager.playerID == 0)
    //    {
    //        if (Input.GetKey(KeyCode.D))
    //        {
    //            moveInputDir = 1;

    //        }
    //        else if (Input.GetKey(KeyCode.A))
    //        {
    //            moveInputDir = -1;

    //        }
    //        else
    //        {
    //            moveInputDir = 0;
    //        }
    //    }

    //    if (playerManager.playerID == 1)
    //    {
    //        if (Input.GetKey(KeyCode.L))
    //        {
    //            moveInputDir = 1;

    //        }
    //        else if (Input.GetKey(KeyCode.J))
    //        {
    //            moveInputDir = -1;

    //        }
    //        else
    //        {
    //            moveInputDir = 0;
    //        }
    //    }


    //    Moving(moveInputDir);

    //}

    public void Moving(int moveDir)
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed * moveDir;

    }

    void RotateCharacter()
    {
        if (target == null) { return; }
        var tmp = target.position.x - transform.position.x;

        if (tmp < 0)
        {
            lookAtDir = -1;
        }
        else
        {
            lookAtDir = 1;

        }

        transform.rotation = Quaternion.Euler(0, 90 * lookAtDir, 0);

    }

    void AttackCambo()
    {
        if (attackTimer > 0)
        {
            attackCount++;
        }

        switch (attackCount)
        {
            case 0:
                break;
            case 1:

                break;

        }

        attackCount = 0;

    }

    public void AttackNormal()
    {
        if(characterAnimationController == null) { return ; }

        canMove = false;
        characterAnimationController.AttackNormalAim();
    }

    public void AttackNormalCallback()
    {
        canMove = true;
        if (normalAttackAMC != null)
        {
            normalAttackAMC.ActiveAttackMachine();

        }
    }

    public void AttackHard()
    {
        if (characterAnimationController == null) { return; }

        canMove = false;
        characterAnimationController.AttackHardAim();
    }

    public void AttackHardCallback()
    {
        canMove = true;

        if (hardAttackAMC != null)
        {
            hardAttackAMC.ActiveAttackMachine();

        }
    }

    public void Guard(bool guardInput)
    {
        if (characterAnimationController == null) { return;}
        if (guardInput)
        {
            if (isGuard) { return; }
            Debug.Log("Character Guard");
            canMove = false;
            isGuard = true;
            characterAnimationController.GuardAnim(isGuard);
        }
        else
        {
            canMove = true;
            isGuard = false;
            characterAnimationController.GuardAnim(isGuard);

        }

    }

   

    public void Jump()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Take " + " Damage");
        currentHp -= damage;

        //bloodVFX.Play();

        if (currentHp < 0)
        {
            Dead();
        }
        characterAnimationController.TakeDamageAnim();


    }

    void Dead()
    {
        Debug.Log("PlayerID:  " + playerManager.playerID + " Dead");
        gameSceneController.EndFight(playerManager);
    }
}
