using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int range;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openFire()
    {
        Instantiate(bullet,transform.position,transform.rotation);
        Debug.Log("open fire!!!1");
    }
}
