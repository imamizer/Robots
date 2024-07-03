using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodingElement_Function : MonoBehaviour
{
    public TMP_Dropdown availableFunctions;
    // Start is called before the first frame update
    void Start()
    {
        availableFunctions.ClearOptions();
        List<string> functionList = new List<string>(RobotController.availableFunctions.Keys);
        availableFunctions.AddOptions(functionList);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectedFunction()
    {
        string selectedFunction = availableFunctions.options[availableFunctions.value].ToString();

        switch (selectedFunction) 
        {
            case "MoveToDestination":
                //add parameters
                break;

        }
    }
}
