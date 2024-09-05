using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public PlayerManager playerManager;
    //public MyPlayerInputController inputController;

    //public PickHeroController pickCharacterController;
    public CharacterAnimationController characterAnimationController;

    public bool canMove;
    [SerializeField] float moveSpeed = 1;
    //public int moveInputDir;
    float lookAtDir;

    public Transform target;

    [SerializeField] AttackMachineController attackMachineController;

    [Space]
    [SerializeField] float maxHp;
    [SerializeField] float currentHp;

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

    public void GetTarget(List<MyCharacterController> targetList)
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


    float attackTimer;
    int attackCount;
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

    public void AttackCallback()
    {
        canMove = true;
        if (attackMachineController != null)
        {
            attackMachineController.ActiveAttackMachine();

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
    }
}
