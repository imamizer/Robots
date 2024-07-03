using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
    {
        //common properties
        public float CPUrequired;
        public float PowerComsumption;
        //navigation specific properties
        public float Speed;
        public float CarryCapacity;


        //navigation functions
        void MoveToDestination(float x, float y)
        { }
        void Rotate(float degree)
        { }
        void LookAt(Vector3 target)
        { }
        void MoveForward(float distance)
        { }
        void Stop()
        { }

        // Start is called before the first frame update
        void Awake()
        {
            Dictionary<string, string> availableFunctions = new Dictionary<string, string>();
            
            availableFunctions.Add("MoveToDestination", "float,float");
            availableFunctions.Add("Rotate", "float");
            availableFunctions.Add("LookAt", "Vector3");
            availableFunctions.Add("MoveForward", "float");
            availableFunctions.Add("Stop", "");
            BroadcastMessage("UpdateAvailableFunctionsFromModules", availableFunctions);
        }

        private void OnDestroy()
        {
            Dictionary<string, string> availableFunctions = new Dictionary<string, string>();

            availableFunctions.Add("MoveToDestination", "float,float");
            availableFunctions.Add("Rotate", "float");
            availableFunctions.Add("LookAt", "Vector3");
            availableFunctions.Add("MoveForward", "float");
            availableFunctions.Add("Stop", "");
            BroadcastMessage("RemoveAvailableFunctionsFromModules", availableFunctions);
        }

        private void OnDisable()
        {
            Dictionary<string, string> availableFunctions = new Dictionary<string, string>();

            availableFunctions.Add("MoveToDestination", "float,float");
            availableFunctions.Add("Rotate", "float");
            availableFunctions.Add("LookAt", "Vector3");
            availableFunctions.Add("MoveForward", "float");
            availableFunctions.Add("Stop", "");
            BroadcastMessage("RemoveAvailableFunctionsFromModules", availableFunctions);
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
