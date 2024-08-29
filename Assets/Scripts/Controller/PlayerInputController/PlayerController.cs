using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID;

    public PickHeroController pickCharacterController;
    [SerializeField] CharacterAnimationController characterAnimationController;

    public bool canMove;
    [SerializeField] float moveSpeed = 1;
    int moveInputDir;
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

        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        MoveInput();

        //Ham nay can chi nen duoc goi khi co input .                     
        RotateCharacter();

        AttackInput();

        if(attackTimer >0)
        {
            attackTimer -= Time.deltaTime;  
        }
    }

    private void LateUpdate()
    {
        //Cai nay phai ben animationController
        if (characterAnimationController != null)
        {
            characterAnimationController.MoveAnim(moveInputDir * lookAtDir);
        }
    }

    void Init()
    {

    }

    void MoveInput()
    {
        if (!canMove)
        {
            moveInputDir = 0;
            Moving(moveInputDir);
            return;
        }

        if (playerID == 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
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
        }

        if (playerID == 1)
        {
            if (Input.GetKey(KeyCode.L))
            {
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
        }


        Moving(moveInputDir);


    }

    void Moving(int moveDir)
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

    public void AttackInput()
    {
        if (playerID == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Attack");
                canMove = false;
                if (characterAnimationController != null)
                {
                    attackTimer = 1;
                    AttackCambo();
                    characterAnimationController.AttackAim();

                }

            }

        }

        if (playerID == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Attack");
                canMove = false;
                if (characterAnimationController != null)
                {
                    characterAnimationController.AttackAim();

                }

            }
        }
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
        attackMachineController.ActiveAttackMachine();
    }

    public void Jump()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Take " + " Damage");
        currentHp -= damage;    
        if(currentHp < 0)
        {
            Dead();
        }
        characterAnimationController.TakeDamageAnim();
    }

    void Dead()
    {
        Debug.Log("PlayerID:  " + playerID + " Dead"); 
    }
}
