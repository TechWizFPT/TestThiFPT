using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMachineController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController caster;
    [SerializeField] Hashtable targetTable;

    [SerializeField] bool isActive;
    [SerializeField] float duration;
    [SerializeField] float cooldown;

    [SerializeField] LayerMask targetLayerMask;
    [SerializeField] float attackDelay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive) { return; }

    }
    void Init()
    {
        cooldown = duration;
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsInLayMask(other.gameObject,targetLayerMask))
        {
            AddTarget(other.gameObject);            
        }
    }

    bool IsInLayMask(GameObject obj,LayerMask mask)
    {
        int layer = obj.layer;
        return (mask & (1<< layer)) != 0;
    }

    void AddTarget(GameObject newTarget)
    {
        var tmp = newTarget.GetComponent<PlayerController>();
        if (tmp != null)
        {
            if (!targetTable.ContainsKey(tmp))
            {
                targetTable.Add(tmp, attackDelay);

            }
        }
    }

    void CountDownDuration()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime; 
        }
    }

    private void OnDisable()
    {

        isActive = false;
        cooldown = 0; 
    }
}
