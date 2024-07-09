using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodingElement_Function : MonoBehaviour
{
    public TMP_Dropdown availableFunctions;
    public Transform Input_object;
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
        int selectedIndex = availableFunctions.value;
        string selectedFunction = availableFunctions.options[selectedIndex].text;
        Debug.Log("Selected option: " + selectedFunction);

        clearInputs();
        switch (selectedFunction) 
        {
            case "MoveToDestination":
                //add parameters
                Instantiate(Input_object, transform);
                Instantiate(Input_object, transform);
                break;
        }
    }

    void clearInputs()
    {
        int childcount = transform.childCount;
        if (childcount > 1) 
        {
            for (int i = 1; i < childcount; i++) 
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
