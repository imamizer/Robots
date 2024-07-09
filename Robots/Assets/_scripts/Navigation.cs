using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
    {
        //common properties
        public float CPUrequired;
        public float PowerComsumption;
        //navigation specific properties
        public float Speed;
        public float CarryCapacity;
        public bool moving = false;
        NavMeshAgent navMeshAgent;
        Vector3 destination;
        //navigation functions
        void MoveToDestination(string koords)
        {
            
            //conver string to variables
            string[] parameters = koords.Split(',');
            destination = new Vector3(float.Parse(parameters[0]), 0, float.Parse(parameters[1]));

        //check if already moving
            if (moving) navMeshAgent.nextPosition.Set(destination.x, destination.y, destination.z);
                        
            else navMeshAgent.destination = destination;
            moving = true;
            
        }
        void Rotate(float degree)
        { }
        void LookAt(Vector3 target)
        { }
        void MoveForward(float distance)
        { }
        void Stop()
        {
        }

        void MoveToDestinationFinished()
        {
            
        }
        // Start is called before the first frame update
        void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
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
        if (moving) 
        {
            if(gameObject.GetComponent<NavMeshAgent>().remainingDistance < 0.1f) 
            {
                moving = false;
            }
        }
        
        
    }

    


}
