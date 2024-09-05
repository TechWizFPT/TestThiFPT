using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] MyCharacterController controller;
    [SerializeField] Animator animator;

    public ParticleSystem punchVFX;
    public ParticleSystem bloodVFX;

    private void Awake()
    {
        controller = GetComponentInParent<MyCharacterController>();  
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

    //AttackAnim 1
    public void AtackAnimCallback()
    {
        punchVFX.Play();

        Debug.Log("Atttack Anim Callback");
        //controller.canMove = true;
        controller.AttackCallback();
    }

    public void TakeDamageAnim()
    {
        bloodVFX.Play();
        animator.SetTrigger("TakeDamage");
    }
}
