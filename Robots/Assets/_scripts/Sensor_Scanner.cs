using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor_Scanner : MonoBehaviour
{
    //common properties
    public float CPUrequired;
    public float PowerComsumption;
    // scanner sensor specific properties
    public float SignalPower;  // 1-100
    public float Frequency;     // scan in time. default 3 (scan every 3 seconds)
    public float ScanChannel;   //layer for materials. 


    public void ActivateSensorOneTime()
    {
        //Physics.OverlapSphere(transform.position,)
        
    }
    public void Output() 
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
