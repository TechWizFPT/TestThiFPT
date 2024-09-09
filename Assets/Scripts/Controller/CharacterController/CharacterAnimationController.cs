using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] CharacterControllerModified controller;
    [SerializeField] Animator animator;

    [Space]
    public ParticleSystem punchVFX;
    public ParticleSystem bloodVFX;

    public bool onGuard;

    private void Awake()
    {
        controller = GetComponentInParent<CharacterControllerModified>();
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

    public void AttackNormalAim()
    {
        animator.SetTrigger("Attack");
    }

    //AttackAnim 1
    public void AtackNormalAnimCallback()
    {
        punchVFX.Play();

        Debug.Log("Atttack Anim Callback");
        //controller.canMove = true;
        controller.AttackNormalCallback();
    }

    public void AttackHardAim()
    {
        animator.SetTrigger("AttackHard");
    }

    //AttackAnim 1
    public void AtackHardAnimCallback()
    {
        punchVFX.Play();

        Debug.Log("Atttack 2 Anim Callback");
        //controller.canMove = true;
        controller.AttackHardCallback();
    }

    public void GuardAnim(bool isGuard)
    {
        //controller.
        Debug.Log("Guard  Anim ");
        if (isGuard)
        {
            animator.SetBool("IsGuard", isGuard);
            onGuard = true;
            animator.SetBool("OnGuard", onGuard);

        }
        else
        {
            onGuard = false;
            animator.SetBool("OnGuard",onGuard);
        }
    }

    public void TakeDamageAnim()
    {
        bloodVFX.Play();
        animator.SetTrigger("TakeDamage");
    }
}
