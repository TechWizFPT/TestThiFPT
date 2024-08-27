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
    int moveDir;
    float lookAtDir;

    [SerializeField] Transform target;

    private void Awake()
    {
        pickCharacterController = GetComponent<PickHeroController>();
        characterAnimationController = GetComponentInChildren<CharacterAnimationController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        
        characterAnimationController.MoveAnim(moveDir * lookAtDir);

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            canMove = false ;
            characterAnimationController.AttackAim();
            
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Be hit");
            characterAnimationController.TakeDamageAnim();
        }

        RotateCharacter();

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.rotation = Quaternion.Euler(0,-90,0);
        //}
    }

    private void LateUpdate()
    {
    }

    void MoveInput()
    {
        if(!canMove) { 
            moveDir = 0;
            Moving(moveDir);
            return;
        }


        if(Input.GetKey(KeyCode.D))
        {
            moveDir = 1;

        }else if(Input.GetKey(KeyCode.A))
        {
            moveDir = -1;

        }
        else
        {
            moveDir = 0;
        }

        Moving(moveDir);

        
    }

    void Moving(int moveDir)
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed * moveDir;

    }

    void RotateCharacter()
    {
        if(target == null) { return; }
        var tmp  = target.position.x - transform.position.x;
        if(tmp < 0)
        {
            lookAtDir = -1;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            lookAtDir = 1;
            transform.rotation = Quaternion.Euler(0, 90, 0);

        }
    }

    public  void Attack()
    {

    }
}
