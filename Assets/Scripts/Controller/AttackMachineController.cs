using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMachineController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MyCharacterController caster;
    [SerializeField] Hashtable targetTable = new Hashtable();


    [SerializeField] bool isActive;
    [SerializeField] float duration;
    [SerializeField] float cooldown;

    [SerializeField] LayerMask targetLayerMask;
    [SerializeField] float attackDelay;

    void Start()
    {
        caster = GetComponentInParent<MyCharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive) { return; }
        CountDownDuration();

    }

    private void OnTriggerStay(Collider other)
    {
        if (IsInLayMask(other.gameObject,targetLayerMask))
        {
            //Debug.Log("Test attack");
            AddTarget(other.gameObject);            
        }
    }
    private void OnDisable()
    {

        isActive = false;
        cooldown = 0; 
    }

    void Init()
    {

        cooldown = duration;
    }

    void ActiveDamage()
    {
        
    }

    public void ActiveAttackMachine()
    {
        //Debug.Log("active attack Machine");
        isActive=true;
        cooldown = duration;
        gameObject.SetActive(isActive);
        caster.punchVFX.Play();
    }

    bool IsInLayMask(GameObject obj,LayerMask mask)
    {
        int layer = obj.layer;
        return (mask & (1<< layer)) != 0;
    }


    void AddTarget(GameObject newTarget)
    {        
        var tmp = newTarget.GetComponentInParent<MyCharacterController>();
        if (tmp != null)
        {
            if (!targetTable.ContainsKey(tmp))
            {
                Debug.Log("add + " + tmp.playerManager.playerID);
                targetTable.Add(tmp, attackDelay);                
                DealDamage(tmp);
            }
        }
    }

    void DealDamage(MyCharacterController target)
    {
        target.TakeDamage(10);
    }

    void CountDownDuration()
    {
        if(cooldown > 0)
        {
            //Debug.Log("countDown");
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = duration;
            isActive = false;
            gameObject.SetActive(isActive);
            targetTable.Clear();
        }
    }

}
