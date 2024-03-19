using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject GunPoint;

    public int rateOfFire;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A)) openFire();
    }

    public void openFire()
    {
        Instantiate(Bullet, GunPoint.transform.position, GunPoint.transform.rotation);
    }
}
