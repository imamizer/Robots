using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.VersionControl.Asset;

public class Robot : MonoBehaviour
{
    int power;
    float powerConsumption;
    int hitpoint;
    float speed;
    float sensorStrenght = 5;
    float carryingIron = 0;

    //---
    int seekRange = 10;

    //---
    GameObject target;

    //---
    NavMeshAgent navagent;
    //---


    //-----modul mount
    public GameObject moduleMount;
    //

    //----weapon modules
    Weapon myWeapon;
    

    // Start is called before the first frame update
    void Start()
    {
        navagent = gameObject.GetComponent<NavMeshAgent>();
        myWeapon = moduleMount.GetComponentInChildren<Weapon>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    
    public void seekResource()
    {
        if (target == null) 
        {
            //random point
            float rndX = transform.position.x + Random.Range(-seekRange, seekRange);
            float rndY = transform.position.y + Random.Range(-seekRange, seekRange);
            float rndZ = transform.position.z + Random.Range(-seekRange, seekRange);

            Vector3 targetpoint = new Vector3(rndX, rndY, rndZ);
            navagent.SetDestination(targetpoint);
        }
    }

    public void movetoTarget(Vector3 targetLoc)
    {
        Debug.Log("approaching target");
        navagent.SetDestination(targetLoc);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("target bulundu " + other.name);
        if (other.tag == "Enemy")
        {
            if (rangeCheck(other.gameObject))
            {
                transform.LookAt(other.transform.position);
                myWeapon.openFire();
            }
        }
            
    }

    bool rangeCheck(GameObject target)
    {
        if (Vector3.Distance(transform.position, target.transform.position) > myWeapon.range) return false;
        else return true;

    }

}
