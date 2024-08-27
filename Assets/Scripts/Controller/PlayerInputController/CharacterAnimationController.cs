using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] Animator animator;
    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();  
        animator = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveAnim(float moveDir)
    {
        //Debug.Log("Move Anim");
        animator.SetFloat("MoveSpeed", moveDir);
    }

    public void AttackAim()
    {
        animator.SetTrigger("Attack");
    }

    public void AtackAnimCallback()
    {
        Debug.Log("Atttack Anim Callback");
        controller.canMove = true;
    }

    public void TakeDamageAnim()
    {
        animator.SetTrigger("TakeDamage");
    }
}
